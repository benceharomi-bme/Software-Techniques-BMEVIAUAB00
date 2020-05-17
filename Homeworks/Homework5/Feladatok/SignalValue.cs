using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signals
{
    public class SignalValue
    {
        public readonly double Value;
        public readonly DateTime TimeStamp;

        public SignalValue(double Value, DateTime TimeStamp)
        {
            this.Value = Value;
            this.TimeStamp = TimeStamp;
        }
        public override string ToString()
        {
            return string.Format("Value: {0}, TimeStamp: {1}", Value, TimeStamp);
        }
    }
}
