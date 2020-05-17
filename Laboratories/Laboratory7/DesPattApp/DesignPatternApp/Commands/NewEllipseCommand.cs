using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFx.Command;

namespace DesignPatternApp.Commands
{
    class NewEllipseCommand : Command
    {
        private int shapeId;
        public override void Execute()
        {
            shapeId = App.Instance.CreateRandomEllipse().Id;
        }
        public override void UnExecute()
        {
            App.Instance.RemoveShape(shapeId);
        }
    }
}
