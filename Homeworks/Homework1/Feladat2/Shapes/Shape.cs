using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public abstract class Shape : IShape
    {
        int x;
        int y;

        public Shape(int x, int y)
        {
            this.x =  x;
            this.y = y;
        }

        public abstract double GetArea();

        public virtual string GetType()
        {
            return "Shape";
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }
    }
}
