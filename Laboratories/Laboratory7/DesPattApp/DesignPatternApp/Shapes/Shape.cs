using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternApp
{
    public abstract class Shape
    {
        // Annak érdekében, hogy később a Memento minta megvalósítása során az alakzatot 
        // és a másolatait össze tudjuk „találtatni”, az egyes alakzatokhoz egy számazonosítót
        // rendelünk, mely az alakzat és másolatai esetében ugyanazt az értéket veszi fel. 
        public readonly int Id;
        // Az első még szabad azonosító (statikus !)
        private static int ShapeCounter;

        // Ha -1-et adunk meg azonosítónak, a konstruktor generál egy új értéket
        // és azt tárolja el. Minden más paraméterérték esetén az új alakzat azonosítója
        // a paraméterben kapott érték lesz.
        public Shape(Rectangle rectangle, int id = -1)
        {
            EnclosingRectangle = rectangle;
            if (id == -1)
                this.Id = ShapeCounter++;
            else
                this.Id = id;
        }

        public Rectangle EnclosingRectangle { get; private set; }

        public Point Position
        {
            get
            {
                return EnclosingRectangle.Location;
            }
        }

        public abstract void OnDraw(Graphics g, Brush brush);
        public abstract Shape CreateCopy();

        public void Draw(Graphics g, bool isSelected)
        {
            // Ha kiválasztott az alakzat, kék szaggatott téglalappal rajzoljuk ki a befoglalóját.
            if (isSelected)
            {
                Pen pen = new Pen(Color.Blue);
                pen.DashStyle = DashStyle.Dash;
                g.DrawRectangle(pen, EnclosingRectangle);
            }

            // Kitöltéshez használt szín/ecset meghatározása: a kiválasztottat piros kitöltéssel.
            Brush brush = isSelected ? Brushes.Red : Brushes.Black;

            // A tényleges kirajzolás, alakzat típus függő, így meghívunk egy abtrakt műveletet
            OnDraw(g, brush);
        }

        public void MoveTo(Point newPos)
        {
            // Az EnclosingRectangle.Location nem állítható, mert egy másolat Locationjét állítanánk (a Rectangle struct!)
            EnclosingRectangle = new Rectangle(newPos, EnclosingRectangle.Size);
        }

        public void Resize(float ratio)
        {
            EnclosingRectangle.Inflate(
                new Size(
                    (int)(EnclosingRectangle.Width * ratio - EnclosingRectangle.Width),
                    (int)(EnclosingRectangle.Height * ratio - EnclosingRectangle.Height))
                );
        }


        // Lehetne ToString()
        public virtual string GetDescription()
        {
            return string.Format("Enclosing rect: x={0}, y={1}, w={2}, h={3}", EnclosingRectangle.X, EnclosingRectangle.Y, EnclosingRectangle.Width, EnclosingRectangle.Height);
        }

    }


}
