using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFunctions
{
    class MainClass
    {
        public Background background;
        public MainClass()
        {
            background = new Background();
        }

        public void Draw(Graphics g)
        {
            background.Draw(g);
        }
    }
}
