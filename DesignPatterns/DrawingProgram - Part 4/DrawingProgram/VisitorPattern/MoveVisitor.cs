using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingProgram.Shapes;
using System.Drawing;

namespace DrawingProgram.VisitorPattern
{
    class MoveVisitor : Visitor
    {
        Point velocity;

        public MoveVisitor(Point velocity)
        {
            this.velocity = velocity;
        }
        
        private void MoveShape(Shape shape)
        {
            shape.x += velocity.X;
            shape.y += velocity.Y;
        }

        public void Visit(RectangleShape recShape)
        {
            MoveShape(recShape);
        }

        public void Visit(EllipseShape ellipseShape)
        {
            MoveShape(ellipseShape);
        }

        public void Visit(ShapeComposite shapeComposite)
        {
            foreach(Shape shape in shapeComposite)
            {
                shape.Accept(this);
            }

            shapeComposite.RecalculateValues();
        }
    }
}
