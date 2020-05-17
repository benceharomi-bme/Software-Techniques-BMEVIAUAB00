using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeInventory si = new ShapeInventory();

            si.AddShape(new Circle(2, 2, 2));
            si.AddShape(new Square(2, 2, 4));
            si.AddShape(new TextArea(2, 2, 4, 5));

            si.ListAll();

            Console.ReadKey();
        }
    }
}
