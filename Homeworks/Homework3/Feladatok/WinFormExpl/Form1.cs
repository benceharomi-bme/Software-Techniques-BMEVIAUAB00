using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormExpl
{
    public partial class Form1 : Form
    {
        FileInfo loadedFile = null;
        int counter;
        readonly int counterInitialValue;
        public Form1()
        {
            InitializeComponent();
            //initialized value is 40 because 40*100millisec = 4 sec
            counterInitialValue = 40;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Closing the application
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputDialog dlg = new InputDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string result = dlg.Path;
                //MessageBox.Show(result);

                DirectoryInfo parentDI = new DirectoryInfo(result);
                listView1.Items.Clear();
                try
                {
                    //getting the name, size and and creationtime of the files
                    foreach (FileInfo fi in parentDI.GetFiles())
                        listView1.Items.Add(new ListViewItem(new string[] { fi.Name, fi.Length.ToString(), fi.CreationTime.ToString(), fi.FullName }));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The process failed: {0}", ex.ToString());
                }

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
                return;

            string fullName = listView1.SelectedItems[0].SubItems[3].Text;
            if (fullName != null)
            {
                loadedFile = new FileInfo(fullName);
                //setting the name of the selected file to the panel's label
                lName.Text = loadedFile.Name.ToString();
                //setting the creationtime of the selected file to the panel's label
                lCreated.Text = loadedFile.CreationTime.ToString();
            }
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
                return;

            string fullName = listView1.SelectedItems[0].SubItems[3].Text;
            if (fullName != null)
            {
                loadedFile = new FileInfo(fullName);
                //printig the file to the textbox
                tContent.Text = File.ReadAllText(fullName);
                //starting the timer
                reloadTimer.Start();
                //initalize the counter
                counter = counterInitialValue;
            }
        }

        private void reloadTimer_Tick(object sender, EventArgs e)
        {
            counter--;

            detailsPanel.Invalidate();
            if (counter <= 0)
            {
                //reseting the timer
                counter = counterInitialValue;
                //re-reading the file
                tContent.Text = File.ReadAllText(loadedFile.FullName);
            }
        }

        private void detailsPanel_Paint(object sender, PaintEventArgs e)
        {
            if (loadedFile != null)
            {
                //painting the rectangle to green and to the wanted length
                e.Graphics.FillRectangle(Brushes.Green, 0, 0, 120 * counter / counterInitialValue, 5);
            }
        }
    }
}
