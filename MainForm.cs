using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tower_Of_Hanoi
{
    public partial class MainForm : Form
    {
        HanoiGame hanoiGame;
        HanoiVisual hanoiVisual;
        HanoiPlayer hanoiPlayer;
        MoveScroller moveScroller;
        int blockCount = 5;

        public MainForm()
        {
            InitializeComponent();
            InitGame();
        }

        private void InitGame()
        {
            hanoiVisual?.ClearExcess();
            hanoiGame = new HanoiGame(blockCount);
            hanoiVisual = new HanoiVisual(hanoiGame, tower1, tower2, tower3, gamePanel);
            hanoiPlayer = new HanoiPlayer(hanoiGame, tower1, tower2, tower3,hanoiVisual);
            moveScroller = new MoveScroller(hanoiGame, hanoiVisual, scrollForward, scrollBack, scrollIndicator);
            hanoiGame.GameFinished += FinishGame;
            //hanoiVisual.Visualize(new HanoiGame.MoveInfo(hanoiGame.towers));
        }

        void FinishGame()
        {
            MessageBox.Show("You win", "congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InitGame();
        }
        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            blockCount = (int)blockCountInputField.Value;
            InitGame();
        }
    }

    class MoveScroller
    {
        HanoiGame game;
        HanoiVisual visual;
        Button forwardButton;
        Button backwardButton;
        Label indicator;

        int scrollIndex = 0;
        int ScrollIndex
        {
            set
            {
                if (value > game.moves.Count - 1 || value < 0)
                {
                    return;
                }
                scrollIndex = value;
                UpdateLabel();
                visual.Visualize(game.moves[scrollIndex]);
            }
            get
            {
                return scrollIndex;
            }
        }

        public MoveScroller(HanoiGame game,HanoiVisual visual, Button forwardButton, Button backwardButton, Label indicator)
        {
            this.game = game;
            this.forwardButton = forwardButton;
            this.backwardButton = backwardButton;
            this.visual = visual;   
            this.indicator = indicator;
            forwardButton.Click += (sender, e) => ChangeScroll(1);
            backwardButton.Click += (sender, e) => ChangeScroll(-1);
            game.BlockMoved += (moveInfo) => ScrollIndex = game.moves.Count - 1;
        }

        void ChangeScroll(int amount)
        {
            ScrollIndex += amount;
        }

        void UpdateLabel()
        {
            HanoiGame.MoveInfo move = game.moves[scrollIndex];
            indicator.Text = (scrollIndex + 1).ToString() + "/" + game.moves.Count.ToString();
        }
    }

    class HanoiPlayer
    {
        HanoiGame game;
        HanoiVisual visual;
        Panel[] panels;
        TowerPanel lastTower;
        delegate void TowerClick(TowerPanel panel, int index);
        TowerPanel[] towerPanels = new TowerPanel[3];

        class TowerPanel
        {
            Panel panel;
            int index;
            public int Index { get;}
            EventHandler eventHandler;
            Color originColor = Color.Gray;
            Color highlightColor = Color.LightGray;
            bool highlighted;

            public bool Highlighted
            {
                set
                {
                    highlighted = value;
                    panel.BackColor = value ? highlightColor : originColor;
                }
                get
                {
                    return highlighted;
                }
            }

            public TowerPanel(Panel panel, TowerClick del, int index)
            {
                this.panel = panel;
                this.index = index;
                panel.BackColor = originColor;
                eventHandler = (sender, e) => del(this, index);
                this.panel.Click += eventHandler;
            }

            public void DeleteEvent()
            {
                this.panel.Click -= eventHandler;
            }
        }

        public HanoiPlayer(HanoiGame game,Panel towerA,Panel towerB,Panel towerC,HanoiVisual visual)
        {
            this.game = game;
            this.visual = visual;
            Panel[] panels = new Panel[3] {towerA,towerB,towerC };
            for (int i = 0; i < 3; i++)
            {
                towerPanels[i] = new TowerPanel(panels[i], TowerClicked, i);
            }
        }

        void TowerClicked(TowerPanel panel, int index)
        {
            if( game.moves.Count != 0 && game.moves[game.moves.Count - 1] != visual.currentMove)
            {
                return;
            }
            if (lastTower == null)
            {
                lastTower = panel;
                panel.Highlighted = true;
            }
            else if (lastTower == panel)
            {
                lastTower = null;
                panel.Highlighted = false;
            }
            else
            {
                game.MoveBlock(game.towers[lastTower.Index], game.towers[index]);
                lastTower.Highlighted = false;
                lastTower = null;
                panel.Highlighted = false;
            }
        }

        public void Stop()
        {

        }
    }

    class HanoiVisual
    {
        HanoiGame game;
        Panel[] panels;
        public int panelHeight;
        public int panelWidhtFactor;
        public int padding = 20;
        BlockInfo[] blockInfos;
        VisualTower[] visualTowers;
        Panel gameArea;
        public HanoiGame.MoveInfo currentMove;

        public class BlockInfo
        {
            public Color color;
            public int width;
            public int height;
            public Block block;
            public Panel panel;
            public BlockInfo(Block block, Color color, int width, int height, Panel gameArea)
            {
                this.color = color;
                this.width = width;
                this.height = height;
                this.block = block;
                panel = new Panel();
                panel.Height = height;
                panel.Width = width;
                panel.BackColor = color;
                panel.BringToFront();
                gameArea.Controls.Add(panel);
            }

            public void ChangePosition(int x, int y)
            {
                panel.Location = new Point(x, y);
            }
        }

        public HanoiVisual(HanoiGame hanoiGame, Panel panelA, Panel panelB, Panel panelC, Panel gameArea)
        {
            game = hanoiGame;
            panels = new Panel[3];
            this.gameArea = gameArea;
            panels[0] = panelA;
            panels[1] = panelB;
            panels[2] = panelC;
            CalculateSize();
            CreateTowers();
            CreateBlocks();
            SetupBlocks();
            //game.BlockMoved += Visualize;
        }

        public void ClearExcess()
        {
            foreach(BlockInfo block in blockInfos)
            {
                gameArea.Controls.Remove(block.panel);
                block.panel.Dispose();
            }
        }
        void CreateTowers()
        {
            visualTowers = new VisualTower[3];
            for (int i = 0; i < 3; i++)
            {
                visualTowers[i] = new VisualTower(panels[i], this, game.blockCount);
            }
        }
        void CalculateSize()
        {
            Panel panel = panels[0];
            int factor;
            if (game.blockCount > 50)
            {
                factor = 1;
            }
            else if (game.blockCount > 25)
            {
                factor = 2;
            }
            else if(game.blockCount > 10)
            {
                factor = 3;
            }
            else
            {
                factor = 4;
            }
            panelHeight = (panel.Height - padding) / (game.blockCount * factor);
            panelWidhtFactor = 200 / game.blockCount;
        }

        void CreateBlocks()
        {
            blockInfos = new BlockInfo[game.blockCount];
            bool bol = true;
            for (int i = 0; i < blockInfos.Length; i++)
            {
                int width = Math.Max(panelWidhtFactor * (i + 1), panels[0].Width + 10);
                Color color = bol ? Color.Red : Color.Blue;
                BlockInfo block = new BlockInfo(game.towers[0][i], color, width, panelHeight,gameArea);
                blockInfos[i] = block;
                bol = !bol;
            }
        }

        void SetupBlocks()
        {
            for(int i = 0; i < blockInfos.Length; i++)
            {
                BlockInfo block = blockInfos[i];
                visualTowers[0].PlaceBlock(block, i);
            }
        }

        public void Visualize(HanoiGame.MoveInfo move)
        {
            for (int i = 0; i <3; i++)
            {
                VisualTower visualTower = visualTowers[i];
                for(int t = 0; t < game.blockCount; t++)
                {
                    Block block = move.towers[i][t];
                    if (block == null)
                    {
                        continue;
                    }
                    visualTower.PlaceBlock(blockInfos[block.size - 1],t);
                }
            }
            currentMove = move;
        }

    }

    class VisualTower
    {
        public Panel panel;
        int[] locations;
        HanoiVisual visual;
        int blockCount;

        public VisualTower(Panel panel, HanoiVisual visual, int blockCount)
        {
            this.panel = panel;
            this.visual = visual;
            this.blockCount = blockCount;
            CalculateYPositions();
        }

        void CalculateYPositions()
        {
            locations = new int[blockCount];
            int y = panel.Location.Y + panel.Height - visual.padding;
            for (int i = blockCount - 1 ; i >= 0; i--)
            {
                locations[i] = y - visual.panelHeight / 2;
                y -= visual.panelHeight;
            }
        }

        int CalculateX(HanoiVisual.BlockInfo block)
        {
            int xPos = (panel.Location.X + panel.Width / 2) - (block.width / 2);
            return xPos;
        }

        public void PlaceBlock(HanoiVisual.BlockInfo block, int index)
        {
            int x = CalculateX(block);
            int y = locations[index];
            block.ChangePosition(x, y);
            block.panel.BringToFront();
        }
    }
}

