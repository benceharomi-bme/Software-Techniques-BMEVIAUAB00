using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SuperCalculator
{
    class DataFifo
    {
        private List<double[]> innerList = new List<double[]>();
        private object syncRoot = new object();
        private ManualResetEvent hasData = new ManualResetEvent(false);
        private ManualResetEvent relaseWorkers = new ManualResetEvent(false);

        public void SignalRelaseWorkers()
        {
            relaseWorkers.Set();
        }

        public void Put(double[] data)
        {
            lock (syncRoot)
            {
                innerList.Add(data);
                hasData.Set();
            }
        }

        public bool TryGet(out double[] data)
        {
            data = null;
            if (WaitHandle.WaitAny(new WaitHandle[] { hasData, relaseWorkers }) == 0)
            {
                lock (syncRoot)
                {
                    if (innerList.Count > 0)
                    {
                        data = innerList[0];
                    innerList.RemoveAt(0);
                    if (innerList.Count == 0)
                        hasData.Reset();
                    return true;
                    }
                    else { return false; }
                }
            }
            return false;
        }
    }
}
