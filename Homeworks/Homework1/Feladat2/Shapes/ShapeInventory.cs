using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class ShapeInventory
    {
        private List<IShape> shapes;

        public ShapeInventory()
        {
            this.shapes = new List<IShape>();
        }

        public void ListAll()
        {
            foreach (IShape sh in shapes)
            {
                Console.WriteLine("Típusa: {0}\tX:{1}\tY:{2}\tTerülete:{3} ", sh.GetType(), sh.GetX(), sh.GetY(), sh.GetArea());
            }
        }

        public void AddShape(IShape sh)
        {
            this.shapes.Add(sh);
        }
    }
}