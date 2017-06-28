using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using DrawingProgram.Commands;
using DrawingProgram.History;
using DrawingProgram.File_IO;
using DrawingProgram.Shapes;
using DrawingProgram.VisitorPattern;
using DrawingProgram.Strategy;

namespace DrawingProgram
{
    public partial class MainForm : Form
    {
        List<Shape> shapeList;

        Point mouseDownLocation;
        Point shapeStartPosition;
        Point mouseStartLocation;

        UndoRedoManager history;

        bool hasSelected;
        bool hasSecondSelected;
        public Shape SelectedShape { get; set; }
        public Shape SecondSelectedShape { get; set; }


        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            shapeList = new List<Shape>();
            history = new UndoRedoManager();
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            Command addShape = new AddShapeCommand(shapeList, new BaseShape("ellipse", 50, 50, 50, 50, EllipseStrategy.Instance()));
            history.Add(addShape);
            Invalidate();
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            Command addShape = new AddShapeCommand(shapeList, new BaseShape("rectangle", 50, 50, 50, 50, RectangleStategy.Instance()));
            history.Add(addShape);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach(Shape g in shapeList)
            {
                g.Draw(e.Graphics);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownLocation = mouseStartLocation = e.Location;
            hasSecondSelected = false;
            
            if (hasSelected && ModifierKeys.HasFlag(Keys.Control))
            {
                foreach (Shape s in shapeList)
                {
                    if (s.dimension.Contains(e.Location))
                    {                    
                        Shape temp = this.SelectedShape;
                    
                        Command selectShape = new SelectShapeCommand(s, this);
                        history.Add(selectShape);

                        this.SelectedShape = temp;

                        SecondSelectedShape = s;

                        shapeStartPosition = s.dimension.Location; 
                        hasSecondSelected = true;

                        ResizeShapeButton.Enabled = true;
                        Invalidate();
                        return;
                    }
                }
                return;
            }
            else
            {
                hasSelected = false;
                // Op geselecteerde shape gedrukt dus er hoeft niks te gebeuren
                if (SelectedShape != null && SelectedShape.dimension.Contains(e.Location))
                {
                    shapeStartPosition = SelectedShape.dimension.Location;
                    hasSelected = true;
                    return;
                }
            }
            
            // check overige shape of er 1 geselecteerd
            foreach (Shape s in shapeList)
            {
                if (s.dimension.Contains(e.Location))
                {
                    Command selectShape = new SelectShapeCommand(s, this);
                    history.Add(selectShape);
                    
                    shapeStartPosition = s.dimension.Location;
                    hasSelected = true;

                    ResizeShapeButton.Enabled = true;
                    Invalidate();
                    return;
                }
            }

            // in de void gedrukt
            if (SelectedShape != null)
            {
                Command deselectShape = new SelectShapeCommand(null, this);
                history.Add(deselectShape);

                ResizeShapeButton.Enabled = false;
                Invalidate();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            bool hasMoved = mouseDownLocation.X != e.X || mouseDownLocation.Y != e.Y;
            if(hasSelected)
            {
                if(hasSecondSelected)
                {
                    ShapeComposite newGroup = new ShapeComposite("group");
                    newGroup.AddChild(SelectedShape);
                    newGroup.AddChild(SecondSelectedShape);

                    shapeList.Remove(SelectedShape);
                    shapeList.Remove(SecondSelectedShape);

                    SecondSelectedShape.selected = false;
                    SecondSelectedShape = null;
                    
                    Command groupShape = new AddShapeCommand(shapeList, newGroup);
                    history.Add(groupShape);

                    Command selectShape = new SelectShapeCommand(newGroup, this);
                    history.Add(selectShape);
                }

                if (hasMoved)
                {
                    Point velocity = new Point(e.Location.X - mouseDownLocation.X, e.Location.Y - mouseDownLocation.Y);
                    Command moveShape = new MoveShapeCommand(SelectedShape, velocity, shapeStartPosition);
                    history.Add(moveShape);                    
                }

                Invalidate();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(shapeList.Count == 0 || SelectedShape == null)
            {
                return;
            }

            // TODO: Rewrite, moving while dragging shape

            //if (hasSelected && e.Button == MouseButtons.Left)
            //{
            //    //SelectedShape.x += e.X - mouseStartLocation.X;
            //    //SelectedShape.y += e.Y - mouseStartLocation.Y;

            //    Invalidate();
            //}

            mouseStartLocation = e.Location;
        }

        private void ResizeShapeButton_Click(object sender, EventArgs e)
        {
            ResizeShapeForm resizeForm = new ResizeShapeForm();
            Shape selectedShape = shapeList.FirstOrDefault(s => s.selected);

            if (selectedShape == null)
            {
                return;
            }

            resizeForm.ShapeWidth = selectedShape.width;
            resizeForm.ShapeHeight = selectedShape.height;

            resizeForm.ShowDialog();

            if (resizeForm.DialogResult == DialogResult.OK)
            {
                Command resizeShapeCommand = new ResizeShapeCommand(selectedShape, resizeForm.ShapeWidth, resizeForm.ShapeHeight);
                history.Add(resizeShapeCommand);                
                Invalidate();
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            history.Undo();
            Invalidate();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            history.Redo();
            Invalidate();
        }
        

        // Open existing file
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    FileInputOutput fileInput = new FileInputOutput(openFileDialog.OpenFile());
            //    fileInput.CreateList();
            //    List<string[]> tempList = fileInput.streamList;

            //    Stack<Command> commandStack = new Stack<Command>();

            //    foreach (string[] shape in fileInput.streamList)
            //    {
            //        if(shape[0] == "rectangle")
            //        {
            //            Command addShape = new AddShapeCommand(shapeList, new BaseShape(shape[0], Int32.Parse(shape[1]), Int32.Parse(shape[2]), Int32.Parse(shape[3]), Int32.Parse(shape[4])));
            //            commandStack.Push(addShape);
            //        }

            //        if(shape[0] == "ellipse")
            //        {
            //            Command addShape = new AddShapeCommand(shapeList, new BaseShape(shape[0], Int32.Parse(shape[1]), Int32.Parse(shape[2]), Int32.Parse(shape[3]), Int32.Parse(shape[4])));
            //            commandStack.Push(addShape);
            //        }

            //        if(shape[0] == "group")
            //        {
            //            ShapeComposite newGroup = new ShapeComposite(shape[0]);
            //            // TODO: pop groupsize add composite shape
            //            //newGroup.AddChild(commandStack.Pop());
            //        }
            //    }
            //}
            //Invalidate();
        }

        // Save current file
        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInputOutput fileOutput = new FileInputOutput(saveFileDialog.OpenFile());
                FileOutputVisitor fileOutPutVisitor = new FileOutputVisitor(fileOutput);

                foreach(Shape shape in shapeList)
                {
                    shape.Accept(fileOutPutVisitor);
                }
                fileOutput.CloseStreamWriter();

                //fileOutput.WriteFile(shapeList);
            }
        }

    }
}
