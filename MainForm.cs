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

        public MainForm()
        {
            InitializeComponent();
            hanoiGame = new HanoiGame(5);
            HanoiVisual hanoiVisual = new HanoiVisual(hanoiGame, tower1, tower2, tower3, gamePanel);
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
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

        public class BlockInfo
        {
            public Color color;
            public int width;
            public int height;
            public Block block;
            public Panel panel;          
            public BlockInfo(Block block,Color color, int width, int height,Panel gameArea)
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

            public void ChangePosition(int x,int y)
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
            panelHeight = (panel.Height - padding) / game.blockCount / 4;
            panelWidhtFactor = 180 / game.blockCount;
        }

        void CreateBlocks()
        {
            blockInfos = new BlockInfo[game.blockCount];
            for (int i = 0; i < blockInfos.Length; i++)
            {
                int width = panelWidhtFactor * (i + 1);
                BlockInfo block = new BlockInfo(game.towers[0][i], Color.Red, width, panelHeight,gameArea);
                blockInfos[i] = block;
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

        void Visualize(HanoiGame.MoveInfo move)
        {

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
            Console.WriteLine(xPos);
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

