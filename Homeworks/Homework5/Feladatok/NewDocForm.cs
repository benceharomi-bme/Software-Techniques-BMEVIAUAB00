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
    /// Új betűtípus paramétereinek (betűtípus neve) megadására szolgál.
    /// </summary>
    public partial class NewDocForm : Form
    {
        public NewDocForm()
        {
            InitializeComponent();
        }

        public string DocName
        {
            get { return tbDocName.Text; }
        }    
    }
}
