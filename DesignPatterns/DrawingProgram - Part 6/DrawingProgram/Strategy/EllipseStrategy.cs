using System.Drawing;

namespace DrawingProgram.Strategy
{
    public class EllipseStrategy : ShapeStrategy
    {
        private static EllipseStrategy instance;

        protected EllipseStrategy()
        {
        }

        public static EllipseStrategy Instance()
        {
            if (instance == null)
            {
                instance = new EllipseStrategy();
            }
            return instance;
        }

        public void Draw(Graphics g, Shape shape)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillEllipse(brush, shape.dimension);
            g.DrawEllipse(new Pen(shape.Color), shape.dimension);
        }
    }
}
