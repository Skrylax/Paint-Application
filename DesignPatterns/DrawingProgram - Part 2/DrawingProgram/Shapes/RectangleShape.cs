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
    }
}
