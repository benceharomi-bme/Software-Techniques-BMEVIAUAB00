using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Signals
{
    /// <summary>
    /// Az alkalmazás főablaka. 2020.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A tabcontrol, melynek tabfülei az egyes betűtípusok dokumentumait megjelenítik.
        /// </summary>
        /// <value>The tab control.</value>
        public TabControl TabControl
        {
            get { return tcDocuments; }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Instance.NewDocument();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Instance.OpenDocument();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Instance.CloseActiveView();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Instance.SaveActiveDocument();
        }

        private void tcDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.Instance.UpdateActiveView();
        }

        private void newViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Instance.CreateViewForActiveDocument();
        }
    }
}
