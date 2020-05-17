using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppFx.CommandBinding
{
    public class CommandBindingManager
    {
        static readonly CommandBindingManager instance = new CommandBindingManager();

        public static CommandBindingManager Instance
        {
            get { return instance; }
        }

        // Command binding-ok az állapot állításhoz
        readonly Dictionary<string, CommandBinding> commandBindingTable = new Dictionary<string, CommandBinding>();

        /// <summary>
        /// Létrehoz egy új command binding-ot és beregisztrálja az adott néven. A név alapján lehet majd kikeresni
        /// és tiltani/engedélyezni. A parancs futtatásakor az action paraméterben megadott eseménykezelő hívódik.
        /// </summary>
        /// <param name="commandName"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public CommandBinding CreateCommandBinding(string commandName, CommandBinding.Action action)
        {
            CommandBinding cmdBinding = new CommandBinding(action);
            registerCommandBinding(commandName, cmdBinding);
            return cmdBinding;
        }

        //public CommandBinding CreateCommandBinding_WithUIConnections(string commandName,
        //    CommandBinding.Action action, ToolStripItem items )
        //{
        //    CommandBinding cmdBinding = new CommandBinding(action);
        //    registerCommandBinding(commandName, cmdBinding);
        //    return cmdBinding;
        //}

        public void EnableCommandBinding(string commandName, bool enable)
        {
            CommandBinding cmdBinding;
            if (commandBindingTable.TryGetValue(commandName, out cmdBinding))
                cmdBinding.IsEnabled = enable;
        }

        public void SelectCommandBinding(string commandName, bool selected)
        {
            CommandBinding cmdBinding;
            if (commandBindingTable.TryGetValue(commandName, out cmdBinding))
                cmdBinding.IsSelected = selected;
        }


        private void registerCommandBinding(string commandName, CommandBinding cmdBinding)
        {
            commandBindingTable.Add(commandName, cmdBinding);
        }
    }
}
