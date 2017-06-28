using System;
using System.Drawing;

namespace DrawingProgram
{
    class EllipseShape : Shape
    {
        public EllipseShape(string t, int x, int y, int w, int h) : base(t, x, y, w, h)
        {

        }

        public override void Draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillEllipse(brush, dimension);
            g.DrawEllipse(new Pen(Color), dimension);
        }

        public override void Move(Point velocity)
        {
            x = x + velocity.X;
            y = y + velocity.Y;
        }

        public override void Resize(float width, float height)
        {
            this.width = Convert.ToInt32(width);
            this.height = Convert.ToInt32(height);
        }
    }
}
