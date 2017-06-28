using DrawingProgram.Shapes;
using System.Collections.Generic;
using System.IO;

namespace DrawingProgram.VisitorPattern
{
    class FileOutputVisitor : VisitorAdapter
    {
        private StreamWriter streamWriter;
        private int depthCounter;

        public FileOutputVisitor(Stream file)
        {
            streamWriter = new StreamWriter(file);
        }

        public override void Visit(BaseShape shape)
        {
            WriteToFile(shape);
        }

        public override void Visit(ShapeComposite shapeComposite)
        {
            WriteToFile(shapeComposite);

            depthCounter++;
            foreach (Shape s in shapeComposite)
            {
                s.Accept(this);
            }
            depthCounter--;
        }

        public override void Visit(ShapeDecorator shapeDecorator)
        {
            WriteToFile(shapeDecorator, true);

            shapeDecorator.decoratedShape.Accept(this); 
        }

        public void ResetDepthCounter()
        {
            depthCounter = 0;
        }

        /// <summary>
        /// Saves all the shapes within the list to a file.
        /// </summary>
        /// <param name="shapeList">List of shapes</param>
        public void Save(List<Shape> shapeList)
        {
            foreach (Shape shape in shapeList)
            {
                ResetDepthCounter();
                shape.Accept(this);
            }
            streamWriter.Close();
        }

        private void WriteToFile(Shape shape, bool addNewLine = false)
        {
            streamWriter.WriteLine(string.Format("{0}{1}", GetWhiteSpaces(), shape.ToString()));
        }

        private string GetWhiteSpaces()
        {
            return new string(' ', depthCounter * 2);
        }
    }
}
