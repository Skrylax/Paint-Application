using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingProgram.Shapes;
using DrawingProgram.File_IO;

namespace DrawingProgram.VisitorPattern
{
    class FileOutputVisitor : Visitor
    {
        FileInputOutput fileOutput;

        public FileOutputVisitor(FileInputOutput fileOutput)
        {
            this.fileOutput = fileOutput;
        }

        public void WriteToFile(Shape shape)
        {
            fileOutput.streamWriter.WriteLine(shape.ToString(0));
        }
        
        public void Visit(EllipseShape ellipseShape)
        {
            WriteToFile(ellipseShape);
        }

        public void Visit(RectangleShape recShape)
        {
            WriteToFile(recShape);
        }

        public void Visit(ShapeComposite shapeComposite)
        {
            WriteToFile(shapeComposite);
        }
    }
}
