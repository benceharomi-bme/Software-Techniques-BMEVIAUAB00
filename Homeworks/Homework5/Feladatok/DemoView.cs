using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Signals
{
    /// <summary>
    /// A karakterek szerkesztőnézete. Egyrészt UserControl, másrészt nézet is.
    /// </summary>
    public partial class DemoView : UserControl, IView
    {
        /// <summary>
        /// A view sorszáma
        /// </summary>
        private int viewNumber;

        /// <summary>
        /// A view sorszáma
        /// </summary>
        public int ViewNumber
        {
            get { return viewNumber; }
            set { viewNumber = value; }
        }

        public DemoView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A dokumentum, melynek adatait a nézet megjeleníti.
        /// TODO: a típusa legyen a Document leszármazottunk.
        /// </summary>
        private Document document;

        public DemoView(Document document)
        {
            InitializeComponent();
            this.document = document;
        }

        /// <summary>
        /// A View interfész Update műveletánek implementációja.
        /// </summary>
        public void Update()
        {
            Invalidate();
        }

        public Document GetDocument()
        {
            return document;
        }

        /// <summary>
        /// A UserControl.Paint felüldefiniálása, ebben rajzolunk.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
