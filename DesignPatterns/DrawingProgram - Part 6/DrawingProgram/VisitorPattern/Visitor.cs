using DrawingProgram.Shapes;

namespace DrawingProgram.VisitorPattern
{
    public interface Visitor
    {
        void Visit(BaseShape shape);
        void Visit(ShapeComposite shapeComposite);
        void Visit(ShapeDecorator shapeDecorator);
    }
}
