using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            ClientSizeChanged += (object s, EventArgs r) => { WindowSize = ClientSize; };
            MouseWheel += Form1_MouseWheel;
            Main = new MainClass();
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            var speed = (e.Delta < 0) ? 0.1f : -0.1f;
            if (Main.background.Show + speed > 0 && Main.background.Show + speed < 2)
            {
                Main.background.Show += speed;
                Main.background.Zoomed += (e.Delta < 0) ? -1 : 1;
            }
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
                currentPositionX = e.X;
                currentPositionY = e.Y;
                float speedX = deltaX / 20.0f;
                float speedY = deltaY / 20.0f;
                Main.background.Origin = new PointF(Main.background.Origin.X + speedX, Main.background.Origin.Y - speedY);
            }
            else
            {
                currentPositionX = e.X;
                currentPositionY = e.Y;
            }
        }
    }
}
