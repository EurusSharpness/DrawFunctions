using System.Drawing;

namespace DrawFunctions
{
    class MainClass
    {
        public Background background;
        public Function function;
        public MainClass()
        {
            background = new Background();
            function = new Function();
        }

        public void Draw(Graphics g)
        {
            background.Draw(g);
            function.Draw(g);
        }
    }
}
