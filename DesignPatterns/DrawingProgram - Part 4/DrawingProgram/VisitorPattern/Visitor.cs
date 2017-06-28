using DrawingProgram.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.VisitorPattern
{
    public interface Visitor
    {
        void Visit(RectangleShape recShape);
        void Visit(EllipseShape ellipseShape);
        void Visit(ShapeComposite shapeComposite);
    }
}
