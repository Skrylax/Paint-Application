using System.Collections.Generic;

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
