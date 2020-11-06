using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFunctions
{
    public partial class Form1 : Form
    {
        public static Size WindowSize;
        MainClass Main;
        private int currentPositionX, currentPositionY;

        public Form1()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            InitializeComponent();
        }

        private void Refresher_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowSize = ClientSize;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            Main = new MainClass();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Main.Draw(g);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
                Main.background.Origin = new PointF(Main.background.Origin.X, Main.background.Origin.Y - 0.5f);
            if (e.KeyCode == Keys.Up)
                Main.background.Origin = new PointF(Main.background.Origin.X, Main.background.Origin.Y + 0.5f);
            if (e.KeyCode == Keys.Left)
                Main.background.Origin = new PointF(Main.background.Origin.X - 0.5f, Main.background.Origin.Y);
            if (e.KeyCode == Keys.Right)
                Main.background.Origin = new PointF(Main.background.Origin.X + 0.5f, Main.background.Origin.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var directionX = (currentPositionX - e.X) > 0 ? Background.MovementState.Right : Background.MovementState.Left;
                var directionY = (currentPositionY - e.Y) > 0 ? Background.MovementState.Down : Background.MovementState.Up;

                currentPositionX = e.X;
                currentPositionY = e.Y;
                if (directionX == Background.MovementState.Left)
                    Main.background.Origin = new PointF(Main.background.Origin.X - 0.2f, Main.background.Origin.Y);
                else if (directionX == Background.MovementState.Right)
                    Main.background.Origin = new PointF(Main.background.Origin.X + 0.2f, Main.background.Origin.Y);
                if (directionY == Background.MovementState.Up)
                    Main.background.Origin = new PointF(Main.background.Origin.X, Main.background.Origin.Y + 0.2f);
                else if (directionY == Background.MovementState.Down)
                    Main.background.Origin = new PointF(Main.background.Origin.X, Main.background.Origin.Y - 0.2f);

            }
            else
            {
                currentPositionX = e.X;
                currentPositionY = e.Y;
            }
        }
    }
}
