using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Circle : Shape
    {
        double r;
        public Circle(int x, int y, double r): base(x, y)
        {
            this.r = r;
        }

        public override string GetType()
        {
            return "Circle";
        }

        public override double GetArea()
        {
            return (r * r * Math.PI);
        }
    }
}
