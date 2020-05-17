using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternApp
{
    public class Ellipse: Shape
    {
        public Ellipse(Rectangle rect, int id = -1) : base(rect, id)
        { }

        public override void OnDraw(Graphics g, Brush brush)
        {
            g.FillEllipse(brush, EnclosingRectangle);
            g.DrawEllipse(Pens.Green, EnclosingRectangle);
        }

        public override Shape CreateCopy()
        {
            return new Ellipse(this.EnclosingRectangle, Id);
        }
    }
}
