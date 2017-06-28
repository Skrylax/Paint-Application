using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Commands
{
    class MoveShapeCommand : Command
    {
        Shape shape;
        Point velocity; // afgelegde afstand over tijd zonder tijd :P
        Point startShapePosition;

        public MoveShapeCommand(Shape s, Point v, Point shapeStartPosition)
        {
            shape = s;
            velocity = v;
            startShapePosition = shapeStartPosition;
        }

        public void Do()
        {
            shape.x = startShapePosition.X + velocity.X;
            shape.y = startShapePosition.Y + velocity.Y;
        }

        public void Undo()
        {
            shape.x -= velocity.X;
            shape.y -= velocity.Y;
        }
    }
}
