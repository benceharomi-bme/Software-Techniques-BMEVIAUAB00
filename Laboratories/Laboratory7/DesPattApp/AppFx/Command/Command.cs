using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFx.Command
{
    /// <summary>
    /// Command-ok ősosztálya.
    /// </summary>
    public abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }
}
