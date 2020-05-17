using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatternApp
{
    public partial class GraphicsView : ViewBase
    {
        public GraphicsView()
        {
            InitializeComponent();
			DoubleBuffered = true;
        }

        protected override void RegisterToDocEvents()
        {
            document.ShapesChanged += DocumentOnShapesChanged;
            document.SelectionChanged += DocumentOnShapesChanged;
        }

        protected override void UnRegisterToDocEvents()
        {
            document.ShapesChanged -= DocumentOnShapesChanged;
            document.SelectionChanged -= DocumentOnShapesChanged;
        }

        private void DocumentOnShapesChanged(object sender, EventArgs eventArgs)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (document == null)
                return;

            Shape selectedShape = document.SelectedShape;

            foreach (Shape s in document.Shapes)
            {
                bool isShapeSelected = s == selectedShape;
                s.Draw(e.Graphics, isShapeSelected);
            }

            //if (DesPattDrawing.Environment.SelectedTool != null)
            //    DesPattDrawing.Environment.SelectedTool.Draw(e.Graphics);
        }
    }
}
