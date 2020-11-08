using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace DrawFunctions
{
    class Background
    {
        const int CanvesSize = 20;
        public double Scale { get; set; }
        public PointF Origin { get; set; }

        public static bool Up, Down, Left, Right;
        public enum MovementState { Up = 1, Down = 2, Left = 3, Right = 4};
        public Background()
        {
            Origin = new PointF(0f, 0f);
            Scale = 1;
        }

        public int GetSize() => CanvesSize;
        
        public void MoveBackground()
        {
            float speed = 0.5f;
            if (Up)
                Origin = new PointF(Origin.X, Origin.Y + speed);
            if (Down)
                Origin = new PointF(Origin.X, Origin.Y - speed);
            if(Right)
                Origin = new PointF(Origin.X + speed, Origin.Y);
            if (Left)
                Origin = new PointF(Origin.X - speed, Origin.Y);
        }
        public void ResetDir()
        {
            Right = Left = Up = Down = false;
        }
        public void Draw(Graphics g)
        {
            float deltaX = Form1.WindowSize.Width / (CanvesSize);
            float deltaY = Form1.WindowSize.Height / (CanvesSize);

            int x, y;
            x = -1 * (CanvesSize / 2) + (int)Origin.X;
            y = (CanvesSize / 2) + (int)Origin.Y;
            for (int i = 0; i <= CanvesSize; i++)
            {
                g.DrawLine(new Pen(brush: Brushes.LightGray, width: 1), new PointF(deltaX * i, 0), new PointF(deltaX * i, Form1.WindowSize.Height));
                g.DrawLine(new Pen(brush: Brushes.LightGray, width: 1), new PointF(0, deltaY * i), new PointF(Form1.WindowSize.Width, deltaY * i));
            }
            for (int i = 0; i <= CanvesSize; i++)
            {

                if (x == 0)
                {
                    int yy = (int)Origin.Y + (CanvesSize / 2);
                    g.DrawLine(new Pen(brush: Brushes.Black, width: 2), new PointF(deltaX * i, 0), new PointF(deltaX * i, Form1.WindowSize.Height));
                    for (int j = 0; j <= CanvesSize; j++)
                    {
                        g.DrawLine(new Pen(brush: Brushes.Black, width: 1), new PointF(deltaX * i - 5, deltaY * j), new PointF(deltaX * i, deltaY * j));
                        if (yy != 0)
                        {
                            var stringSize = g.MeasureString($"{yy}", new Font("", 7));
                            if (j > 0 && j < CanvesSize)
                                g.DrawString($"{yy}", new Font("", 7), Brushes.Black, new PointF(deltaX * i - 5 - stringSize.Width, deltaY * j - (stringSize.Height / 2)));

                        }
                        yy -= (int)Scale;
                    }
                }
                if (y == 0)
                {
                    int xx =  (int)Origin.X - (CanvesSize / 2);
                    g.DrawLine(new Pen(brush: Brushes.Black, width: 2), new PointF(0, deltaY * i), new PointF(Form1.WindowSize.Width, deltaY * i));
                    for (int j = 0; j <= CanvesSize; j++)
                    {
                        g.DrawLine(new Pen(brush: Brushes.Black, width: 1), new PointF(deltaX * j, deltaY * i), new PointF(deltaX * j, deltaY * i + 5));
                        if (xx != 0)
                        {
                            var stringSize = g.MeasureString($"{xx}", new Font("", 7));
                            if(j > 0 && j < CanvesSize)
                                g.DrawString($"{xx}", new Font("", 7), Brushes.Black, new PointF(deltaX * j - stringSize.Width/2, deltaY * (i) + (stringSize.Height / 2)));

                        }
                        xx += (int)Scale;
                    }
                }
                x += (int)Scale;
                y -= (int)Scale;
            }

            g.DrawString($"X = {(int)Origin.X}  Y= {(int)Origin.Y}", new Font("", 8),Brushes.Black, 0, 0);
        }
    }
}
