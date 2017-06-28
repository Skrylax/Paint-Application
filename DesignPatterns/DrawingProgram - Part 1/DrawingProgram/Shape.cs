using System.Drawing;

namespace DrawingProgram
{
    abstract class Shape
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public bool selected;

        public Rectangle dimension
        {
            get
            {
                return new Rectangle(x, y, width, height);
            }
        }

        protected Color Color
        {
            get
            {
                return selected ? Color.Red : Color.Black;
            }
        } 

        public Shape(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            width = w;
            height = h;
        }

        public abstract void Draw(Graphics g);


    }
}
