using DrawingProgram.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.VisitorPattern
{
    class ResizeVisitor : Visitor
    {
        float width;
        float height;

        public ResizeVisitor(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        public void ResizeShape(Shape shape)
        {
            shape.width = Convert.ToInt32(width);
            shape.height = Convert.ToInt32(height);
        }

        public void Visit(RectangleShape recShape)
        {
            ResizeShape(recShape);
        }

        public void Visit(EllipseShape ellipseShape)
        {
            ResizeShape(ellipseShape);
        }

        public void Visit(ShapeComposite shapeComposite)
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

    }
}
