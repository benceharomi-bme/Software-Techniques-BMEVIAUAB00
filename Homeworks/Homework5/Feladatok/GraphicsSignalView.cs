using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Signals
{
    public partial class GraphicsSignalView : UserControl, IView
    {
        // A view sorszáma
        private int viewNumber;
        // A dokumentum, melynek adatait a nézet megjeleníti.
        private SignalDocument document;
        float pixelPerSec = 60.0f;
        float pixelPerValue = 4.0f;
        double zoom = 1;

        public GraphicsSignalView()
        {
            InitializeComponent();
        }

        public GraphicsSignalView(SignalDocument document)
        {
            InitializeComponent();
            this.document = document;
        }

        // A view sorszáma
        public int ViewNumber
        {
            get { return viewNumber; }
            set { viewNumber = value; }
        }

        // A View interfész Update műveletánek implementációja.
        public void Update()
        {
            Invalidate();
        }

        public Document GetDocument()
        {
            return document;
        }

        // A UserControl.Paint felüldefiniálása, ebben rajzolunk.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // tengelyek rajzolasa, x iranyba eggyel eltolva, hogy latszodjon az y tengely is
            Pen pen = new Pen(Color.Green, 2);
            pen.DashStyle = DashStyle.Dot;
            pen.EndCap = LineCap.ArrowAnchor;
            int x = ClientSize.Width;
            int y = ClientSize.Height;
            e.Graphics.DrawLine(pen, 1, y, 1, 0);
            e.Graphics.DrawLine(pen, 0, y / 2, x, y / 2);

            // boolean az elso pont megkulonboztetesehet
            bool first = true;
            // valtozok inicializalasa
            float actualx = 0.0f;
            float actualy = 0.0f;
            float prevx = 0.0f;
            float prevy = 0.0f;
            SignalValue prev = null;
            foreach(SignalValue signalValue in document.Signals)
            {
                if (first)
                {
                    // masodpercebe atvaltva, skalárral és zoommal beszorozva a nagyitashoz
                    actualy = (float)(y / 2 - (((signalValue.Value) * pixelPerValue)) * zoom);
                    // elso pont koordinata kiszamolasa utan a boolean atallitasa
                    first = false;
                }
                else
                {
                    // masodpercebe atvaltva, skalárral és zoommal beszorozva a nagyitashoz
                    actualx += (float) (((signalValue.TimeStamp.Ticks - prev.TimeStamp.Ticks) / 10000000.0f * pixelPerSec)*zoom);
                    // masodpercebe atvaltva, skalárral és zoommal beszorozva a nagyitashoz
                    actualy = (float) (y / 2 - ((signalValue.Value*pixelPerValue))*zoom);
                    // vonal kirajzolasa
                    e.Graphics.DrawLine(new Pen(Color.Blue), prevx, prevy, actualx, actualy);
                }
                // koordinatakbol egyet kivonok, hogy a negyzet kozepen legyen a pont
                e.Graphics.FillRectangle(Brushes.Blue, actualx-1, actualy-1, 3, 3);
                // aktualis koordinatak hozzarendelese az elozo koordinatahoz,
                // a kovetkezo korbeni vonalrajzolas kezdopontjanak erdekeben
                prevx = actualx;
                prevy = actualy;
                prev = signalValue;
            }
        }

        private void plusB_Click(object sender, EventArgs e)
        {
            // zoom valtozo novelese
            zoom = zoom * 1.2;
            Invalidate();
        }

        private void minusB_Click(object sender, EventArgs e)
        {
            // zoom valtoozo csokkentese
            zoom = zoom / 1.2;
            Invalidate();
        }
    }
}
