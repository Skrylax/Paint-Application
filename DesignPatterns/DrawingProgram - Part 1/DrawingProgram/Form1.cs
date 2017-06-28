using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

/*
Maak een eerste versie van de grafische editor die ellipsen en rechthoeken kan tekenen, 
selecteren, 
verplaatsen 
en van grootte veranderen.
*/

namespace DrawingProgram
{
    public partial class Form1 : Form
    {
        List<Shape> shapeList;
        Point mouseDownLocation;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            shapeList = new List<Shape>();
        }

        //Draw basic rectangle
        private void buttonDrawRec_Click(object sender, EventArgs e)
        {
            Shape rectangle = new RectangleShape(50,50,50,50);
            shapeList.Add(rectangle);
            Invalidate();
        }
        
        //Draw basic ellipse
        private void buttonDrawEllipse_Click(object sender, EventArgs e)
        {
            Shape ellipse = new EllipseShape(50,50,50,50);
            shapeList.Add(ellipse);
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
            mouseDownLocation = e.Location;
            bool hasSelected = false;

            foreach (Shape s in shapeList)
            {
                if (s.dimension.Contains(e.Location))
                {
                    s.selected = true;
                    hasSelected = true;
                    ResizeButton.Enabled = true;
                    break;
                }   
            }

            if(!hasSelected)
            {
                shapeList.ForEach(s => s.selected = false);
                ResizeButton.Enabled = false;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
            {
                return;
            }

            if(shapeList.Count == 0)
            {
                return;
            }

            // Select first selected shape.
            Shape selectedShape = shapeList.FirstOrDefault(s => s.selected);

            if (selectedShape == null)
            {
                return;
            }

            if (selectedShape.dimension.Contains(e.Location))
            {
                selectedShape.y += e.Y - mouseDownLocation.Y;
                selectedShape.x += e.X - mouseDownLocation.X;

                // Re-calibrate on each move operation.
                this.mouseDownLocation = new Point { X = e.X, Y = e.Y };

                Invalidate();
            }
        }

        private void ResizeButton_Click(object sender, EventArgs e)
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

            if(resize.DialogResult == DialogResult.OK)
            {
                selectedShape.width = resize.ShapeWidth;
                selectedShape.height= resize.ShapeHeight;
                Invalidate();
            }
        }
    }
}
