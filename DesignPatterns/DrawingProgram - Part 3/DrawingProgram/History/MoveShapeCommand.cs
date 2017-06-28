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

        public MoveShapeCommand(Shape s, Point v, Point shapeStartPosition)
        {
            shape = s;
            velocity = v;
        }

        public void Do()
        {
            shape.Move(velocity);
        }

        public void Undo()
        {
            shape.Move(new Point(-velocity.X, -velocity.Y));
        }
    }
}
