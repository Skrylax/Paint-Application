using DrawingProgram.Shapes;

namespace DrawingProgram.VisitorPattern
{
    class VisitorAdapter : Visitor
    {
        public virtual void Visit(ShapeDecorator shapeDecorator)
        {
        }

        public virtual void Visit(ShapeComposite shapeComposite)
        {
        }

        public virtual void Visit(BaseShape shape)
        {
        }
    }
}
