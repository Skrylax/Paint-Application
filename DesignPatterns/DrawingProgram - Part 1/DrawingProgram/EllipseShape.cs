using System.Drawing;

namespace DrawingProgram
{
    class EllipseShape : Shape
    {
        public EllipseShape(int x, int y, int w, int h) : base(x, y, w, h)
        {

        }

        public override void Draw(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillEllipse(brush, dimension);
            g.DrawEllipse(new Pen(Color), dimension);
        }
    }
}
