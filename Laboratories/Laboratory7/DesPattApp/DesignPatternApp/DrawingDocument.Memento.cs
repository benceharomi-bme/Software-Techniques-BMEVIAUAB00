using System.Collections.Generic;

namespace DesignPatternApp
{
    public partial class DrawingDocument
    {
        public class Memento
        {
            private List<Shape> shapes = new List<Shape>();
            private Shape selectedShape;

            public Memento(List<Shape> shapes, Shape selectedShape)
            {
                // Deep copyra van szükségünk!
                foreach (Shape shape in shapes)
                    this.shapes.Add(shape.CreateCopy());

                // Be kell állítsuk selectedShape-nek. Az új Shape listában kell a megfelelõ
                // elemre hivatkoznia, nem az eredetiben. Be kell állítsuk.
                this.selectedShape = null;
                for (int i = 0; i < shapes.Count; ++i)
                    if (shapes[i] == selectedShape)
                    {
                        this.selectedShape = this.shapes[i];
                        break;
                    }
            }

            public void GetState(out List<Shape> shapes, out Shape selectedShape)
            {
                shapes = this.shapes;
                selectedShape = this.selectedShape;
            }
        }

    }
}