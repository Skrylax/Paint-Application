using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Strategy
{
    public class RectangleStategy : ShapeStrategy
    {
        private static RectangleStategy instance;

        protected RectangleStategy()
        {

        }

        public static RectangleStategy Instance()
        {
            if(instance == null)
            {
                instance = new RectangleStategy();
            }
            return instance;
        }

        public void Draw(Graphics g, Shape shape)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, shape.dimension);
            g.DrawRectangle(new Pen(shape.Color), shape.dimension);
        }
    }
}
