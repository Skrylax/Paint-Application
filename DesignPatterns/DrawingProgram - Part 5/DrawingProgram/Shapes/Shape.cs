using DrawingProgram.VisitorPattern;
using System.Drawing;

namespace DrawingProgram
{
    public abstract class Shape
    {
        public string type;
        public bool selected;
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public virtual Rectangle dimension
        {
            get
            {
                return new Rectangle(x, y, width, height);
            }
        }

        public Color Color
        {
            get
            {
                return selected ? Color.Red : Color.Black;
            }
        } 

        public Shape(string t) 
            :this(t, 0,0,0,0)
        {

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
        public abstract void Accept(Visitor visitor);
        
        public virtual string ToString(int depthCounter)
        {
            string whiteSpaces = new string(' ', depthCounter * 2);
            string s;

            s = whiteSpaces + type + " " + x.ToString() + " " + y.ToString() + " " + width.ToString() + " " + height.ToString(); 

            return s;
        }
    }
}
