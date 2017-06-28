using System.Drawing;

namespace DrawingProgram
{
    public abstract class Shape
    {
        public string type;
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

        public Shape(string t, int x, int y, int w, int h)
        {
            type = t;
            this.x = x;
            this.y = y;
            width = w;
            height = h;
        }

        public abstract void Draw(Graphics g);

        public override string ToString()
        {
            string s;

            s = type + " " + x.ToString() + " " + y.ToString() + " " + width.ToString() + " " + height.ToString(); 

            return s;
        }
    }
}
