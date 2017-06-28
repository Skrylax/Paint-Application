using DrawingProgram.VisitorPattern;
using System.Drawing;

namespace DrawingProgram.Commands
{
    class MoveShapeCommand : Command
    {
        Shape shape;
        Point velocity;
        Point inverseVelocity;

        public MoveShapeCommand(Shape s, Point v, Point shapeStartPosition)
        {
            shape = s;
            velocity = v;
            inverseVelocity = new Point(-v.X, -v.Y);
        }

        public void Do()
        {
            MoveVisitor moveVisitor = new MoveVisitor(velocity);
            shape.Accept(moveVisitor);
        }

        public void Undo()
        {
            MoveVisitor moveVisitor = new MoveVisitor(inverseVelocity);
            shape.Accept(moveVisitor);
        }
    }
}
