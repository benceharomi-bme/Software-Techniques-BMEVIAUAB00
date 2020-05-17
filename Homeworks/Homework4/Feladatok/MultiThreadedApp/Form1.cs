using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreadedApp
{
    public partial class Form1 : Form
    {
        delegate void BikeAction(Button bike);
        Random random = new Random();
        //Step1-hez ManualResetEvent
        private ManualResetEvent Step1 = new ManualResetEvent(false);
        //Step2-höz AutoResetEvent
        private AutoResetEvent Step2 = new AutoResetEvent(false);
        //A megtett pixelek számolásához long változó
        private long count;
        private object syncRoot = new object();
        //A start pozíció tárolásáhpz egy változó
        private int startPosition;

        public Form1()
        {
            InitializeComponent();
            //Start pozició inicializálása
            startPosition = bBike1.Left;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void BikeThreadFunction(object param)
        {
            try
            {
                Button bike = (Button)param;
                //A gombhoz tartózó aktuálisan őt vezérlő szál objektum tárolása
                bike.Tag = Thread.CurrentThread;

                while (bike.Left < pStart.Left)
                {
                    MoveBike(bike);
                    Thread.Sleep(100);
                }

                //A startnál a többi bicikli bevárása
                if (Step1.WaitOne())
                {
                    while (bike.Left < pDepo.Left)
                    {
                        MoveBike(bike);
                        Thread.Sleep(100);
                    }
                }

                //A depoban várakozás
                if (Step2.WaitOne())
                {
                    while (bike.Left < pTarget.Left)
                    {
                        MoveBike(bike);
                        Thread.Sleep(100);
                    }
                }
            }
            catch (ThreadInterruptedException)
            {
                // Lenyeljük, de szigorúan kizárólag a ThreadInterruptedException-t.
                // Ha nem kezelnénk az Interrupt hatására a szállfüggvényünk
                // és az alkalmazásunk is csúnyán "elszállna".
            }
        }

        public void MoveBike(Button bike)
        {
            if (InvokeRequired)
            {
                Invoke(new BikeAction(MoveBike), bike);
            }
            else
            {
                //Egy változóban a random szám tárolása
                int rand = random.Next(3, 9);
                bike.Left += rand;
                //A megtett pixellel való növelése a számlálónak.
                increasePixels(rand);
            }
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            StartBike(bBike1);
            StartBike(bBike2);
            StartBike(bBike3);
        }

        private void StartBike(Button bBike)
        {
            Thread t = new Thread(BikeThreadFunction);
            bBike.Tag = t;
            t.IsBackground = true; // Ne blokkolja a szál a processz megszűnését
            t.Start(bBike);
        }

        private void bStep1_Click(object sender, EventArgs e)
        {
            //Ellenőrzés, hogy mindegyik bicikli a startnál van-e
            if(bBike1.Left >= pStart.Left && bBike2.Left >= pStart.Left && bBike3.Left >= pStart.Left)
            {
                Step1.Set();
            }
        }

        private void bStep2_Click(object sender, EventArgs e)
        {
            Step2.Set();
        }

        public void increasePixels(long step)
        {
            //Szálbiztosság biztosítása
            lock (syncRoot)
            {
                //Számláló növelése a megadott számmal
                count += step;
            }
        }

        public long getPixels()
        {
            lock(syncRoot)
            {
                return count;
            }
        }

        private void bCounter_Click(object sender, EventArgs e)
        {
            //A gomb szövegének beállítása a megtett pixelre
            bCounter.Text = getPixels().ToString();
        }

        private void bike_Click(object sender, EventArgs e)
        {
            Button bike = (Button)sender;
            Thread thread = (Thread)bike.Tag;
            // Ha még nem indítottuk ez a szálat, ez null.
            if (thread == null)
                return;
            // Megszakítjuk a szál várakozását, ez az adott szálban egy
            // ThreadInterruptedException-t fog kiváltani
            // A függvény leírásáról részleteket az előadás anyagaiban találsz
            thread.Interrupt();
            // Megvárjuk, amíg a szál leáll
            thread.Join();

            //A step1 resetelés, hogy újra bevárják egymást
            Step1.Reset();

            //A bicikli visszaküldése a kezdő pozícióhoz
            bike.Left = startPosition;
        }
    }
}
