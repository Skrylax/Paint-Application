using DrawingProgram.Shapes;
using System;
using System.Drawing;

namespace DrawingProgram.VisitorPattern
{
    class ResizeVisitor : VisitorAdapter
    {
        float width;
        float height;

        public ResizeVisitor(float width, float height)
        {
            this.width = width;
            this.height = height;
        }
        
        public override void Visit(BaseShape shape)
        {
            shape.width = Convert.ToInt32(width);
            shape.height = Convert.ToInt32(height);
        }
        
        public override void Visit(ShapeComposite shapeComposite)
        {
            Rectangle dimension = shapeComposite.dimension;
            
            float widthFactor = width / dimension.Width;
            float heightFactor = height / dimension.Height;

            foreach (Shape shape in shapeComposite)
            {
                width = Convert.ToInt32(shape.width * widthFactor);
                height = Convert.ToInt32(shape.height * heightFactor);

                shape.Accept(this);
            }
        }

        public override void Visit(ShapeDecorator shapeDecorator)
        {
            shapeDecorator.decoratedShape.Accept(this);
        }
    }
}
