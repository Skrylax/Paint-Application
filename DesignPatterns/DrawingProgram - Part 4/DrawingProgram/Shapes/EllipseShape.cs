using System;
using System.Drawing;
using DrawingProgram.VisitorPattern;

namespace DrawingProgram
{
    public class EllipseShape : Shape
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

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
