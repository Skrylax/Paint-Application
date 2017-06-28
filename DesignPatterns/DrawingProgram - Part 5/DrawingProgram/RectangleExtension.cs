using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram
{
    public static class RectangleExtension
    {
        public static Rectangle Add(this Rectangle lhs, Rectangle rhs)
        {
            Rectangle rect = new Rectangle();
            int minX = rhs.Left < lhs.Left ? rhs.Left : lhs.Left;
            int minY = rhs.Top < lhs.Top ? rhs.Top : lhs.Top;

            int maxX = rhs.Right > lhs.Right ? rhs.Right : lhs.Right;
            int maxY = rhs.Bottom > lhs.Bottom ? rhs.Bottom : lhs.Bottom;

            rect.X = minX;
            rect.Y = minY;
            rect.Width = maxX - minX;
            rect.Height = maxY - minY;

            return rect;
        }
    }
}
