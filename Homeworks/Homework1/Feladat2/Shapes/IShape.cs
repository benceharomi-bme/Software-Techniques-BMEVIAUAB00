using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public interface IShape
    {
        string GetType();
        int GetX();
        int GetY();
        double GetArea();

    }
}