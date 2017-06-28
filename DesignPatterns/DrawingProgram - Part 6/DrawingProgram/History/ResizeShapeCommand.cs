using DrawingProgram.VisitorPattern;

namespace DrawingProgram.Commands
{
    class ResizeShapeCommand : Command
    {
        Shape shape;
        int oldWidth;
        int oldHeight;
        int width;
        int height;
        
        public ResizeShapeCommand(Shape s, int w, int h)
        {
            shape = s;
            oldWidth = shape.width;
            oldHeight = shape.height;
            width = w;
            height = h;
        }

        public void Do()
        {
            ResizeVisitor resizeVisitor = new ResizeVisitor(width, height);
            shape.Accept(resizeVisitor);
        }

        public void Undo()
        {
            ResizeVisitor resizeVisitor = new ResizeVisitor(oldWidth, oldHeight);
            shape.Accept(resizeVisitor);
        }
    }
}
