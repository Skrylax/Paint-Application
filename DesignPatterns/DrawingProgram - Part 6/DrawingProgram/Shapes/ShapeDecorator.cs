using System.Drawing;
using DrawingProgram.VisitorPattern;

namespace DrawingProgram.Shapes
{
    public class ShapeDecorator : Shape
    {
        public Shape decoratedShape;
        public string ornament;
        public enum OrnamentPosition { top, bottom, left, right};
        public OrnamentPosition position;

        public override bool selected
        {
            get
            {
                return decoratedShape.selected;
            }

            set
            {
                decoratedShape.selected = value;
            }
        }

        public override Rectangle dimension
        {
            get
            {
                return decoratedShape.dimension;
            }
        }

        public ShapeDecorator() : this(0,0,0,0, null, string.Empty, OrnamentPosition.bottom) { }

        public ShapeDecorator(int x, int y, int w, int h, Shape decoratedShape, string ornament, OrnamentPosition ornamentPosition) : base("ornament", x, y, w, h)
        {
            this.decoratedShape = decoratedShape;
            this.ornament = ornament;
            position = ornamentPosition;
        }
        
        private Point GetPosition()
        {
            Rectangle dimension = decoratedShape.dimension;

            if(position == OrnamentPosition.top)
            {
                x = dimension.Left + (dimension.Width / 2);
                y = dimension.Top - 20;
            }
            else if(position == OrnamentPosition.bottom)
            {
                x = dimension.Left + (dimension.Width / 2);
                y = dimension.Bottom + 20;
            }
            else if (position == OrnamentPosition.left)
            {
                x = dimension.Left - ornament.Length * 4;
                y = dimension.Top + (dimension.Height / 2) - 2;
            }
            else if (position == OrnamentPosition.right)
            {
                x = dimension.Right + ornament.Length * 4;
                y = dimension.Top + (dimension.Height / 2) - 2;
            }
            return new Point(x, y);
        }

        public override void Draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            Font font = new Font("Arial", 8);
            StringFormat stringformat = new StringFormat();
            stringformat.Alignment = StringAlignment.Center;
            g.DrawString(ornament, font, brush, GetPosition(), stringformat);

            decoratedShape.Draw(g);
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return type + " " + position.ToString().ToLower() + " " + ornament;
        }
    }
}
