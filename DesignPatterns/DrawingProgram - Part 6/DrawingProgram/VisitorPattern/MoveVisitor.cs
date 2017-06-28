using DrawingProgram.Shapes;
using System.Drawing;

namespace DrawingProgram.VisitorPattern
{
    class MoveVisitor : VisitorAdapter
    {
        Point velocity;

        public MoveVisitor(Point velocity)
        {
            this.velocity = velocity;
        }
        
        public override void Visit(BaseShape shape)
        {
            shape.x += velocity.X;
            shape.y += velocity.Y;
        }
        
        public override void Visit(ShapeComposite shapeComposite)
        {
            foreach(Shape shape in shapeComposite)
            {
                shape.Accept(this);
            }

            shapeComposite.RecalculateValues();
        }

        public override void Visit(ShapeDecorator shapeDecorator)
        {
            shapeDecorator.decoratedShape.Accept(this);
        }
    }
}
