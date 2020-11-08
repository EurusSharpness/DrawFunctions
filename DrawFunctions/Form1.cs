using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
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
            Main.background.MoveBackground();
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClientSize = new Size(700, 700);
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
            if (e.KeyCode == Keys.Down)
                Background.Down = true;
            if (e.KeyCode == Keys.Up)
                Background.Up = true;
            if (e.KeyCode == Keys.Left)
                Background.Left = true;
            if (e.KeyCode == Keys.Right)
                Background.Right = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                Background.Down = false;
            if (e.KeyCode == Keys.Up)
                Background.Up = false;
            if (e.KeyCode == Keys.Left)
                Background.Left = false;
            if (e.KeyCode == Keys.Right)
                Background.Right = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var deltaX = currentPositionX - e.X;
                var deltaY = currentPositionY - e.Y;
                var directionX = (deltaX) > 0 ? Background.MovementState.Right : Background.MovementState.Left;
                var directionY = (deltaY) > 0 ? Background.MovementState.Down : Background.MovementState.Up;
                currentPositionX = e.X;
                currentPositionY = e.Y;
                float speedX =  deltaX / 20.0f;
                float speedY = deltaY / 20.0f;
                if (directionX == Background.MovementState.Left)
                    Main.background.Origin = new PointF(Main.background.Origin.X + speedX, Main.background.Origin.Y);
                else if (directionX == Background.MovementState.Right)
                    Main.background.Origin = new PointF(Main.background.Origin.X + speedX, Main.background.Origin.Y);
                if (directionY == Background.MovementState.Up)
                    Main.background.Origin = new PointF(Main.background.Origin.X, Main.background.Origin.Y - speedY);
                else if (directionY == Background.MovementState.Down)
                    Main.background.Origin = new PointF(Main.background.Origin.X, Main.background.Origin.Y - speedY);
            }
            else
            {
                currentPositionX = e.X;
                currentPositionY = e.Y;
            }
        }
    }
}
