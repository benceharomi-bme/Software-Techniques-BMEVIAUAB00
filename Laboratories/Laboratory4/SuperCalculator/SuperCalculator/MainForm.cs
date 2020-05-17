using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SuperCalculator
{
	public partial class MainForm : Form
	{
		private DataFifo fifo = new DataFifo();
		private delegate void AddResultToList(double[] parameters, double result);
		bool closing = false;

		public MainForm()
		{
			InitializeComponent();
			double p1 = 12.34;
			double p2 = 56.78;
			textBoxParam1.Text = p1.ToString();
			textBoxParam2.Text = p2.ToString();
			new Thread(WorkerThread) { Name = "Szal1" }.Start();
			new Thread(WorkerThread) { Name = "Szal2" }.Start();
			new Thread(WorkerThread) { Name = "Szal3" }.Start();
		}

		private void ShowResult(double[] parameters, double result)
		{
			if (closing)
				return;
			if (InvokeRequired)
			{
				Invoke(new AddResultToList(ShowResult),
				new object[] { parameters, result });
			}
			else if (!IsDisposed)
			{
				ListViewItem lvi = listViewResult.Items.Add(parameters[0] + " # " + parameters[1] + " = " + result);
				listViewResult.EnsureVisible(lvi.Index);
				listViewResult.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			}
		}

		private void buttonCalcResult_Click(object sender, EventArgs e)
		{
			double p1, p2 = 0;
			if (Double.TryParse(textBoxParam1.Text, out p1) &&
				(Double.TryParse(textBoxParam2.Text, out p2)))
			{
				double[] parameters = new double[] { p1, p2 };
				fifo.Put(parameters);
			}
			else MessageBox.Show(this, "Invalid parameter!", "Error");
		}

		private void CalculatorThread(object arg)
		{
			double[] parameters = (double[])arg;
			double result = Algorithms.SuperAlgorithm.Calculate(parameters);
			ShowResult(parameters, result);
		}

		private void WorkerThread()
		{
			double[] data = null;
			while (!closing)
			{
				if (fifo.TryGet(out data))
				{
					double result = Algorithms.SuperAlgorithm.Calculate(data);
					ShowResult(data, result);
				}
				//Thread.Sleep(500);
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			closing = true;
			fifo.SignalRelaseWorkers();
		}

	}
}