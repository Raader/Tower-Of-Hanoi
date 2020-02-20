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
        Label[] labels;
        Label label;
        HanoiGame hanoiGame;
        public MainForm()
        {
            InitializeComponent();
            labels = new Label[3];
            labels[0] = new Label();
            label = labels[0];
            label = null;
            Console.WriteLine(labels[0]);
            hanoiGame = new HanoiGame(5);
            Panel[] panels = new Panel[3];
            panels[0] = tower1;
            panels[1] = tower2;
            panels[2] = tower3;
            HanoiVisual visual = new HanoiVisual(hanoiGame, panels);
            VisualTower tower = new VisualTower(hanoiGame.towers[0], tower1, visual,gamePanel);
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

        public class BlockInfo
        {
            public Color color;
            public int width;
            public int height;

            public BlockInfo(Color color, int width, int height)
            {
                this.color = color;
                this.width = width;
                this.height = height;
            }
        }

        public HanoiVisual(HanoiGame hanoiGame, Panel[] panels)
        {
            game = hanoiGame;
            this.panels = panels.Length > 3 ? null : panels;
            CalculateSize();
            //Construct();
        }

        void CalculateSize()
        {
            Panel panel = panels[0];
            panelHeight = (panel.Height - padding) / game.blockCount;
            panelWidhtFactor = 100 / game.blockCount;
        }

        void Construct()
        {
            for (int i = 0; i < 3; i++)
            {
                Tower tower = game.towers[i];
                Panel panel = panels[3];
                for(int y = 0; y< game.blockCount; y++)
                {
                    Block block = tower[y];
                    if (block == null)
                    {
                        continue;
                    }

                }
            }
        }

        void Visualize(HanoiGame.MoveInfo move)
        {

        }

    }

    class VisualTower
    {
        public Tower tower;
        public Panel panel;
        int[] locations;
        HanoiVisual hanoiVisual;

        public VisualTower(Tower tower, Panel panel, HanoiVisual visual,Panel gamePanel)
        {
            this.tower = tower;
            this.panel = panel;
            this.hanoiVisual = visual;
            CalculateYPositions();
            Panel newPanel = new Panel();
            newPanel.Height = hanoiVisual.panelHeight;
            newPanel.Width = hanoiVisual.panelWidhtFactor * 5;
            newPanel.BackColor = Color.Red;
            newPanel.Location = new Point(CalculateX(new HanoiVisual.BlockInfo(Color.White, hanoiVisual.panelWidhtFactor * 5, hanoiVisual.panelHeight)), locations[0]);
            gamePanel.Controls.Add(newPanel);
            newPanel.BringToFront();
        }

        void CalculateYPositions()
        {
            locations = new int[tower.blockCount];
            int y = panel.Location.Y + panel.Height - hanoiVisual.padding;
            for (int i = tower.blockCount - 1 ; i >= 0; i--)
            {
                locations[i] = y - hanoiVisual.panelHeight / 2;
                y -= hanoiVisual.panelHeight;
            }
        }

        int CalculateX(HanoiVisual.BlockInfo block)
        {
            int xPos = (panel.Location.X + panel.Width / 2) - (block.width / 2);
            return xPos;
        }
    }

    class VisualBlock
    {
        public Block block;
        public Color color;
        public Panel panel;

        public VisualBlock(Block block, Color color,Panel panel)
        {
            this.block = block;
            this.color = color;
            this.panel = panel;
        }
    }
}

