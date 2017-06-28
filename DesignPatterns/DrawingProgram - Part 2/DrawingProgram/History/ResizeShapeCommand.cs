using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            shape.width = width;
            shape.height = height;
        }

        public void Undo()
        {
            shape.width = oldWidth;
            shape.height = oldHeight;
        }
    }
}
