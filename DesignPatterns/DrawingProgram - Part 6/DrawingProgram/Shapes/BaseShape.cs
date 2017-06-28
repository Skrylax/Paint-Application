using System.Drawing;
using DrawingProgram.VisitorPattern;
using DrawingProgram.Strategy;

namespace DrawingProgram
{
    public class BaseShape : Shape
    {
        private ShapeStrategy strat;

        public BaseShape(string t, ShapeStrategy strat) : base(t, 0, 0, 0, 0)
        {
            this.strat = strat;
        }

        public BaseShape(string t, int x, int y, int w, int h, ShapeStrategy strat) : base(t, x, y, w, h)
        {
            this.strat = strat;
        }

        public override void Draw(Graphics g)
        {
            strat.Draw(g, this);
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
