using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using DrawingProgram.Commands;
using DrawingProgram.History;
using DrawingProgram.File_IO;

namespace DrawingProgram
{
    public partial class MainForm : Form
    {
        List<Shape> shapeList;
        Point mouseDownLocation;
        Point shapeStartPosition;
        UndoRedoManager history;
        bool hasSelected;
        Point mouseStartLocation;

        public Shape SelectedShape { get; set; }

        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            shapeList = new List<Shape>();
            history = new UndoRedoManager();
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            Command addShape = new AddShapeCommand(shapeList, new EllipseShape("ellipse", 50, 50, 50, 50));
            history.Add(addShape);
            Invalidate();
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            Command addShape = new AddShapeCommand(shapeList, new RectangleShape("rectangle", 50, 50, 50, 50));
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
            hasSelected = false;

            // Op geselecteerde shape gedrukt dus er hoeft niks te gebeuren
            if (SelectedShape != null && SelectedShape.dimension.Contains(e.Location))
            {
                shapeStartPosition = SelectedShape.dimension.Location;
                hasSelected = true;
                return;
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
            if(hasSelected && hasMoved)
            {
                Point velocity = new Point(e.Location.X - mouseDownLocation.X, e.Location.Y - mouseDownLocation.Y);
                Command moveShape = new MoveShapeCommand(SelectedShape, velocity, shapeStartPosition);
                history.Add(moveShape);
                Invalidate();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(shapeList.Count == 0 || SelectedShape == null)
            {
                return;
            }

            if (hasSelected && e.Button == MouseButtons.Left)
            {
                SelectedShape.x += e.X - mouseStartLocation.X;
                SelectedShape.y += e.Y - mouseStartLocation.Y;

                Invalidate();
            }

            mouseStartLocation = e.Location;
        }

        private void ResizeShapeButton_Click(object sender, EventArgs e)
        {
            ResizeShape resize = new ResizeShape();
            Shape selectedShape = shapeList.FirstOrDefault(s => s.selected);

            if (selectedShape == null)
            {
                return;
            }

            resize.ShapeWidth = selectedShape.width;
            resize.ShapeHeight = selectedShape.height;

            resize.ShowDialog();

            if (resize.DialogResult == DialogResult.OK)
            {
                Command resizeShapeCommand = new ResizeShapeCommand(selectedShape, resize.ShapeWidth, resize.ShapeHeight);
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
        
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInputOutput fileInput = new FileInputOutput(openFileDialog.OpenFile());
                fileInput.CreateList();

                foreach (string[] shape in fileInput.streamList)
                {
                    if(shape[0] == "rectangle")
                    {
                        Command addShape = new AddShapeCommand(shapeList, new RectangleShape(shape[0], Int32.Parse(shape[1]), Int32.Parse(shape[2]), Int32.Parse(shape[3]), Int32.Parse(shape[4])));
                        history.Add(addShape);
                    }

                    if(shape[0] == "ellipse")
                    {
                        Command addShape = new AddShapeCommand(shapeList, new EllipseShape(shape[0], Int32.Parse(shape[1]), Int32.Parse(shape[2]), Int32.Parse(shape[3]), Int32.Parse(shape[4])));
                        history.Add(addShape);
                    }
                }
            }
            Invalidate();
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInputOutput fileOutput = new FileInputOutput(saveFileDialog.OpenFile());
                fileOutput.WriteFile(shapeList);
            }
        }

    }
}
