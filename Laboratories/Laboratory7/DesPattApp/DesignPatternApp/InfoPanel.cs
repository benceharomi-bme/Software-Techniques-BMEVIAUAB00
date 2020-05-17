using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatternApp
{
    public partial class InfoPanel : ViewBase
    {
        public InfoPanel()
        {
            InitializeComponent();
        }

        private bool ignoreIndexChanged;

        protected override void RegisterToDocEvents()
        {
            document.ShapesChanged += Document_ShapesChanged;
            document.SelectionChanged += Document_SelectionChanged;
        }

        protected override void UnRegisterToDocEvents()
        {
            document.ShapesChanged -= Document_ShapesChanged;
            document.SelectionChanged -= Document_SelectionChanged;
            clearItems();
        }

        private void Document_ShapesChanged(object sender, EventArgs e)
        {
            try
            {
                ignoreIndexChanged = true;

                listBox.Items.Clear();

                if (document == null)
                    return;

                foreach (Shape s in document.Shapes)
                    listBox.Items.Add(s.GetDescription());

                listBox.SelectedIndex = document.SelectedShapeIndex;
            }
            finally
            {
                ignoreIndexChanged = false;
            }
        }

        private void Document_SelectionChanged(object sender, EventArgs e)
        {
            if (document == null)
                return;

            try
            {
                ignoreIndexChanged = true;
                listBox.SelectedIndex = document.SelectedShapeIndex;
            }
            finally
            {
                ignoreIndexChanged = false;
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ignoreIndexChanged)
                return;

            App.Instance.SetSelectedShape(listBox.SelectedIndex);
        }

        private void clearItems()
        {
            try
            {
                ignoreIndexChanged = true;
                listBox.Items.Clear();
            }
            finally
            {
                ignoreIndexChanged = false;
            }
        }
    }
}
