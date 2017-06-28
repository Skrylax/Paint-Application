using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using DrawingProgram.Commands;
using DrawingProgram.History;
using DrawingProgram.Shapes;
using DrawingProgram.VisitorPattern;
using DrawingProgram.Strategy;
using DrawingProgram.Forms;

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
                // Selected shape was selected, nothing has to happen.
                if (SelectedShape != null && SelectedShape.dimension.Contains(e.Location))
                {
                    shapeStartPosition = SelectedShape.dimension.Location;
                    hasSelected = true;
                    return;
                }
            }
            
            // Check shapes if one was selected.
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

            // Pressed within the void.
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
                    ShapeComposite newGroup = new ShapeComposite();
                    newGroup.AddChild(SelectedShape);
                    newGroup.AddChild(SecondSelectedShape);
                    
                    MacroCommand macroCommandSelectedShape = new MacroCommand();
                    macroCommandSelectedShape.Add(new CustomCommand(
                        () =>
                        {
                            shapeList.Remove(SelectedShape);
                            shapeList.Remove(SecondSelectedShape);
                        },
                        () =>
                        {
                            shapeList.Add(newGroup.groupMembers[0]);
                            shapeList.Add(newGroup.groupMembers[1]);
                        }
                    ));
                    
                    SecondSelectedShape.selected = false;
                    SecondSelectedShape = null;

                    macroCommandSelectedShape.Add(new AddShapeCommand(shapeList, newGroup));
                    history.Add(macroCommandSelectedShape);
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

            resizeForm.ShapeWidth = selectedShape.dimension.Width;
            resizeForm.ShapeHeight = selectedShape.dimension.Height;

            resizeForm.ShowDialog();

            if (resizeForm.DialogResult == DialogResult.OK)
            {
                Command resizeShapeCommand = new ResizeShapeCommand(selectedShape, resizeForm.ShapeWidth, resizeForm.ShapeHeight);
                history.Add(resizeShapeCommand);                
                Invalidate();
            }
        }

        private void OrnamentButton_Click(object sender, EventArgs e)
        {
            DecoratorForm decoratorForm = new DecoratorForm();
            Shape selectedShape = shapeList.FirstOrDefault(s => s.selected);

            if (selectedShape == null)
            {
                return;
            }

            decoratorForm.ShowDialog();

            if (decoratorForm.DialogResult == DialogResult.OK)
            {
                string ornamentText = decoratorForm.Ornament;

                ShapeDecorator ornament = new ShapeDecorator(selectedShape.x + 50, selectedShape.y, 50, 50, selectedShape, ornamentText, decoratorForm.position);

                MacroCommand macroCommand = new MacroCommand();                
                macroCommand.Add( new CustomCommand(
                    () => shapeList.Remove(selectedShape),
                    () => shapeList.Add(selectedShape)));
                macroCommand.Add(new AddShapeCommand(shapeList, ornament));

                history.Add(macroCommand);

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
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInputVisitor fileInputVisitor = new FileInputVisitor(openFileDialog.OpenFile(), shapeList);
                fileInputVisitor.Load(); 
            }

            Invalidate();
        }

        // Save current file
        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileOutputVisitor fileOutPutVisitor = new FileOutputVisitor(saveFileDialog.OpenFile());
                fileOutPutVisitor.Save(shapeList);
            }
        }
    }
}
