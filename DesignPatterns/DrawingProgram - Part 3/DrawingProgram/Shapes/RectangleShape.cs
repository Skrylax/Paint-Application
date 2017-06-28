using System;
using System.Drawing;

namespace DrawingProgram
{
    class RectangleShape : Shape
    {
        public RectangleShape(string t, int x, int y, int w, int h) : base(t, x, y, w, h)
        {
            
        }

        public override void Draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, dimension);
            g.DrawRectangle(new Pen(Color), dimension);
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
