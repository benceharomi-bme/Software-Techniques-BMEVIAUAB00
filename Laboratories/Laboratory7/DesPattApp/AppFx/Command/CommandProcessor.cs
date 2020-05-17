using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFx.Command
{
    public class CommandProcessor
    {
        Stack<Command> commands = new Stack<Command>();
        public void ExecuteCommand(Command cmd)
        {
            cmd.Execute();
            commands.Push(cmd);
        }
        public void UnExecuteLastCommand()
        {
            // Ha üres, nem csinálunk semmit
            if (!commands.Any())
                return;
            Command lastCommand = commands.Pop();
            lastCommand.UnExecute();
        }
        public void Clear()
        {
            commands.Clear();
        }
        public bool HasAny { get { return commands.Any(); } }
    }
}

