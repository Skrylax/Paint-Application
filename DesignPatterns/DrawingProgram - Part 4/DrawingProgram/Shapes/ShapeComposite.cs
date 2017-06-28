using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DrawingProgram.VisitorPattern;
using System.Collections;

namespace DrawingProgram.Shapes
{
    public class ShapeComposite : Shape, IEnumerable
    {
        public List<Shape> groupMembers { get; set; }
        
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

        public void RecalculateValues()
        {
            Rectangle rect = dimension;
            x = rect.X;
            y = rect.Y;
            width = rect.Width;
            height = rect.Height;
        }

        public void AddChild(Shape s)
        {
            groupMembers.Add(s);
            RecalculateValues();
        }

        public void RemoveChild(Shape s)
        {
            groupMembers.Remove(s);
            RecalculateValues();
        }

        public override void Draw(Graphics g)
        {
            Rectangle newRect = dimension;
            g.DrawRectangle(new Pen(Color), newRect);

            foreach (Shape s in groupMembers)
            {
                s.Draw(g);
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

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public IEnumerator GetEnumerator()
        {
            return groupMembers.GetEnumerator();
        }
    }
}
