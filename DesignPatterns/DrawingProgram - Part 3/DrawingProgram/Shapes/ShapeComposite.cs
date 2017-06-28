using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DrawingProgram.Shapes
{
    class ShapeComposite : Shape
    {
        List<Shape> groupMembers;
        
        public override Rectangle dimension
        {
            get
            {
                Rectangle rect = new Rectangle();
                if (groupMembers.Count > 0)
                    rect = groupMembers[0].dimension;

                foreach(Shape s in groupMembers)
                {
                    if (s == groupMembers[0])
                        continue;

                    rect = rect.Add(s.dimension);
                }

                return rect;
            }
        }

        public ShapeComposite(string t) : base(t)
        {
            groupMembers = new List<Shape>();
        }

        public void AddChild(Shape s)
        {
            groupMembers.Add(s);
            RecalculateValues();
        }

        private void RecalculateValues()
        {
            Rectangle rect = dimension;
            x = rect.X;
            y = rect.Y;
            width = rect.Width;
            height = rect.Height;
        }

        public void RemoveChild(Shape s)
        {
            groupMembers.Remove(s);
            RecalculateValues();
        }

        public override void Draw(Graphics g)
        {
            //SolidBrush brush = new SolidBrush(Color.White);
            //g.FillRectangle(brush, dimension);

            Rectangle newRect = dimension;
            g.DrawRectangle(new Pen(Color), newRect);

            foreach (Shape s in groupMembers)
            {
                s.Draw(g);
            }
        }

        public override void Move(Point velocity)
        {
            foreach (Shape s in groupMembers)
            {
                s.Move(velocity);
            }

            RecalculateValues();
        }

        public override void Resize(float width, float height)
        {
            float widthFactor = width / dimension.Width;
            float heightFactor = height / dimension.Height;
            
            foreach (Shape s in groupMembers)
            {
                int w = Convert.ToInt32(s.width * widthFactor);
                int h = Convert.ToInt32(s.height * heightFactor);

                s.Resize(w, h);
            }
        }
        
        public override string ToString(int depthCounter)
        {
            string whiteSpaces = new string(' ', depthCounter * 2);
            string output = whiteSpaces + type + " " + groupMembers.Count().ToString() + Environment.NewLine;

            depthCounter++;

            for (int i = 0; i < groupMembers.Count; i++)
            {
                output += groupMembers[i].ToString(depthCounter) 
                    + ((i == groupMembers.Count-1) ? "" : Environment.NewLine);
            }
            
            return output;
        }

    }
}
