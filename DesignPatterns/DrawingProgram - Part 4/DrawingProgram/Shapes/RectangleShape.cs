using System;
using System.Drawing;
using DrawingProgram.VisitorPattern;

namespace DrawingProgram
{
    public class RectangleShape : Shape
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

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
