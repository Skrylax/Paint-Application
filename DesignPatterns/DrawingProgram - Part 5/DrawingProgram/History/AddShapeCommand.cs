using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Commands
{
    class AddShapeCommand : Command
    {
        List<Shape> shapeList;
        Shape shape;

        public AddShapeCommand(List<Shape> shapes, Shape s)
        {
            shapeList = shapes;
            shape = s;
        }

        public void Do()
        {
            shapeList.Add(shape);
        }

        public void Undo()
        {
            shapeList.Remove(shape);
        }
    }
}
