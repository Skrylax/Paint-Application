using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingProgram.VisitorPattern;

namespace DrawingProgram.Strategy
{
    public interface ShapeStrategy
    {
        void Draw(Graphics g, Shape shape);
    }
}
