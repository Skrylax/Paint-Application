using System;
using DrawingProgram.Shapes;
using System.IO;
using DrawingProgram.Strategy;
using System.Collections.Generic;

namespace DrawingProgram.VisitorPattern
{
    class FileInputVisitor : VisitorAdapter
    {
        StreamReader streamReader;
        List<Shape> shapeList;
        string currentLine;

        public FileInputVisitor(Stream file, List<Shape> shapeList)
        {
            streamReader = new StreamReader(file);
            this.shapeList = shapeList;
        }

        public override void Visit(BaseShape shape)
        {
            string[] lineSplit = SplitCurrentLine();
            shape.x = Convert.ToInt32(lineSplit[1]);
            shape.y = Convert.ToInt32(lineSplit[2]);
            shape.width = Convert.ToInt32(lineSplit[3]);
            shape.height = Convert.ToInt32(lineSplit[4]);
        }
        
        public override void Visit(ShapeComposite shapeComposite)
        {
            // For now we know groups are always 2 shapes big
            int childCount = 2;
            for(int i = 0;  i < childCount; i++)
            {
                currentLine = streamReader.ReadLine();
                Shape shape = CreateShapeFromLine(currentLine);
                shape.Accept(this);
                shapeComposite.AddChild(shape);
            }
        }

        public override void Visit(ShapeDecorator shapeDecorator)
        {
            string[] lineSplit = SplitCurrentLine();
            string text = lineSplit[2];
            ShapeDecorator.OrnamentPosition position;
            Enum.TryParse(lineSplit[1], out position);

            currentLine = streamReader.ReadLine();
            Shape shape = CreateShapeFromLine(currentLine);
            shape.Accept(this);
            shapeDecorator.decoratedShape = shape;
            shapeDecorator.ornament = text;
            shapeDecorator.position = position;
        }

        /// <summary>
        /// Loads the shapes from the file.
        /// </summary>
        public void Load()
        {
            currentLine = string.Empty;
            while ((currentLine = streamReader.ReadLine()) != null)
            {
                Shape shape = CreateShapeFromLine(currentLine);
                shape.Accept(this);
                shapeList.Add(shape);
            }

            streamReader.Close();
        }

        private string[] SplitCurrentLine()
        {
            return currentLine.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private Shape CreateShapeFromLine(string line)
        {
            string[] lineSplit = SplitCurrentLine();
            Shape shape = null;

            switch (lineSplit[0])
            {
                case "rectangle":
                    shape = new BaseShape(lineSplit[0], RectangleStategy.Instance());
                    break;
                case "ellipse":
                    shape = new BaseShape(lineSplit[0], EllipseStrategy.Instance());
                    break;
                case "group":
                    shape = new ShapeComposite();
                    break;
                case "ornament":
                    shape = new ShapeDecorator();
                    break;
            }            

            return shape;
        }
    }
}
