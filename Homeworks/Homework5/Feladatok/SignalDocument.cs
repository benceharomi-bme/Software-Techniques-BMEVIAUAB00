using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signals
{
    public class SignalDocument : Document
    {
        List<SignalValue> signals = new List<SignalValue>();

        private SignalValue[] testValues = new SignalValue[]
        {
            new SignalValue(10, new DateTime(2020, 1, 1, 0, 0, 0, 111)),
            new SignalValue(20, new DateTime(2020, 1, 1, 0, 0, 1, 876)),
            new SignalValue(30, new DateTime(2020, 1, 1, 0, 0, 2, 300)),
            new SignalValue(10, new DateTime(2020, 1, 1, 0, 0, 3, 232)),
            new SignalValue(-10, new DateTime(2020, 1, 1, 0, 0, 5, 885)),
            new SignalValue(-19, new DateTime(2020, 1, 1, 0, 0, 6, 125))
        };

        public IReadOnlyList<SignalValue> Signals
        {
            get { return signals; }
        }

        public SignalDocument(string name)
            : base(name)
        {
            signals.AddRange(testValues);
        }

        public override void SaveDocument(string filePath)
        {
            // using blokk annak biztositasara, hogy kivetel eseten is lezarodjon a fajlunk
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                //minden jelertekre
                foreach (SignalValue signalValue in signals)
                {
                    // UTC ido-re alakitas
                    string dt = signalValue.TimeStamp.ToUniversalTime().ToString("o");
                    // kiiras az elvarasoknak megfeleloen
                    sw.WriteLine(signalValue.Value + "\t" + dt);
                }
            }
        }

        public override void LoadDocument(string filePath)
        {
            signals.Clear();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // whitespacek torlese
                    line = line.Trim();
                    // tabulatoroknal sorok vagasa, tombbe rakasa
                    string[] columns = line.Split('\t');
                    // a tomb elso eleme a double ertek, ezt parseoljuk
                    double d = double.Parse(columns[0]);
                    // a tomb masodik eleme a UTC datum
                    DateTime utcDt = DateTime.Parse(columns[1]);
                    // helyi idove alakitas
                    DateTime localDt = utcDt.ToLocalTime();
                    // uj jelertek letrehozasa
                    SignalValue signalValue = new SignalValue(d,localDt);
                    // signals listaba felvetele
                    signals.Add(signalValue);
                }
            }
            // adatok tracelese
            TraceValues();
            UpdateAllViews();
        }

        void TraceValues()
        {
            foreach (SignalValue signal in signals)
                Trace.WriteLine(signal.ToString());
        }

    }
}
