using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Square : Shape
    {
        int a;
        public Square(int x, int y, int a) :base(x, y)
        {
            this.a = a;
        }

        public override string GetType()
        {
            return "Square";
        }

        public override double GetArea()
        {
            return (a * a);
        }
    }
}
