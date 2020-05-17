using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFx.DocView;

namespace DesignPatternApp
{
    public partial class DrawingDocument: Document
    {
        List<Shape> shapes = new List<Shape>();
        private Shape selectedShape;

        #region Events

        /// <summary>
        /// Akkor kerül elsütésre, ha a shapes lista, vagy annak valamelyik eleme módosul.
        /// </summary>
        public event EventHandler ShapesChanged;
        /// <summary>
        /// Akkor kerül elsütésre, ha a egy korábbitól eltérő alakzat került kiválasztásra.
        /// </summary>
        public event EventHandler SelectionChanged;

        #endregion

        public Memento CreateMemento()
        {
            return new Memento(shapes, selectedShape);
        }

        public void RestoreFromMemento(Memento m)
        {
            m.GetState(out shapes, out selectedShape);
            fireShapesChanged();
            fireSelectionChanged();
        }

        /// <summary>
        /// Visszaadja az alakzatok gyűjteményét.
        /// </summary>
        public IEnumerable<Shape> Shapes
        {
            get { return shapes; }
        }

        /// <summary>
        /// Az aktuálisan kiválasztott alakzatot adja vissza (null-t, ha nincs 
        /// alakzat kiválasztva), illetve módosításával új alakzat választható ki.
        /// </summary>
        public Shape SelectedShape
        {
            get { return selectedShape; }
            set
            {
                // Ha nincs változás, ne süssünk el feleslegesen változás eseményt
                if (selectedShape == value)
                    return;

                selectedShape = value;

                fireSelectionChanged();
            }
        }

        /// <summary>
        /// Az aktuálisan kiválasztott alakzat indexét adja vissza (-1-et, ha nincs 
        /// alakzat kiválasztva), illetve módosításával új alakzat választható ki.
        /// </summary>
        public int SelectedShapeIndex
        {
            get
            {
                for (int i = 0; i < shapes.Count; ++i)
                    if (shapes[i] == selectedShape)
                        return i;
                return -1;
            }
            set
            {
                if (value >= shapes.Count)
                    return;
                if (value == -1)
                    SelectedShape = null;
				else
					SelectedShape = shapes[value];
            }
        }


        void fireShapesChanged()
        {
            if (ShapesChanged != null)
                ShapesChanged(this, null);
        }

        void fireSelectionChanged()
        {
            if (SelectionChanged != null)
                SelectionChanged(this, null);
        }

        public Rect CreateRect(Rectangle enclosingRectangle)
        {
            var shape = new Rect(enclosingRectangle);
            shapes.Add(shape);
            fireShapesChanged();
            return shape;
        }

        public Ellipse CreateEllipse(Rectangle enclosingRectangle)
        {
            var shape = new Ellipse(enclosingRectangle);
            shapes.Add(shape);
            fireShapesChanged();
            return shape;
        }

        public void RemoveShape(int shapeId)
        {
            // Kikeressük a shapeId azonosítójú alakzatot.
            Shape shapeToRemove = null;
            foreach (var shape in shapes)
                if (shape.Id == shapeId)
                {
                    shapeToRemove = shape;
                    break;
                }

            // Ha nem találtuk, nem csinálunk semmit
            if (shapeToRemove == null)
                return;

            // Megnézzük, hogy az utolsó van-e kiválasztva. Ha igen: nem lesz kiválasztott alakzat.
            if (shapeToRemove == selectedShape)
                SelectedShape = null;

            // Távolítsuk el az elemet
            shapes.Remove(shapeToRemove);
            fireShapesChanged();
        }

        public void Clear()
        {
            shapes.Clear();
            fireShapesChanged();
            SelectedShape = null;
        }
    }
}
