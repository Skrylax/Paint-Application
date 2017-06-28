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

        public ShapeComposite() : base("group")
        {
            groupMembers = new List<Shape>();
        }

        /// <summary>
        /// Recalculates the values of the dimension
        /// </summary>
        public void RecalculateValues()
        {
            Rectangle rect = dimension;
            x = rect.X;
            y = rect.Y;
            width = rect.Width;
            height = rect.Height;
        }

        /// <summary>
        /// Adds a child shape to the composite.
        /// </summary>
        /// <param name="s">Shape</param>
        public void AddChild(Shape s)
        {
            groupMembers.Add(s);
            RecalculateValues();
        }

        /// <summary>
        /// Removes a child shape from the composite.
        /// </summary>
        /// <param name="s">Shape</param>
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
        public override string ToString()
        {
            return type + " " + groupMembers.Count().ToString();
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
