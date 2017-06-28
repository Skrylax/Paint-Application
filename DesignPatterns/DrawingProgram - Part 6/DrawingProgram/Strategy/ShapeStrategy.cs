using System.Drawing;

namespace DrawingProgram.Strategy
{
    public interface ShapeStrategy
    {
        void Draw(Graphics g, Shape shape);
    }
}
