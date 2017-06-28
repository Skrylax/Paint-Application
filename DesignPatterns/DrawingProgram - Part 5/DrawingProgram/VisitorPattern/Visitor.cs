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
        void Visit(BaseShape shape);
        void Visit(ShapeComposite shapeComposite);
    }
}
