using System;
using System.Collections.Generic;
using System.Text;
using Controls;

namespace Shapes
{
    class TextArea : Textbox, IShape
    {

        public TextArea(int x, int y, int w, int h) : base(x, y, w, h)
        {        }

        public double GetArea()
        {
            return (GetWidth()*GetHeight());
        }

        public string GetType()
        {
            return "TestArea";
        }

    }
}
