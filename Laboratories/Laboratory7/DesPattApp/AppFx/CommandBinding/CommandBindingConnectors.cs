using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppFx.CommandBinding
{

    /// <summary>
    /// Absztrakt ős olyan adapter osztályok számára, melyek valamilyen típusú felületelemet
    /// kötnek össze CommandBinding objektumokkal.
    /// </summary>
    public abstract class CommandBindingConnectorBase
    {
        protected CommandBinding m_commandBinding;
        protected abstract void HandleEnableChangedEvent(object sender, CommandBinding.EnableChangedEventArgs e);
        protected abstract void HandleVisibleChangedEvent(object sender, CommandBinding.VisibleChangedEventArgs e);
        protected abstract void HandleSelectedChangedEvent(object sender, CommandBinding.SelectedChangedEventArgs e);

        protected CommandBindingConnectorBase(CommandBinding commandBinding)
        {
            m_commandBinding = commandBinding;
            m_commandBinding.EnableChanged += this.HandleEnableChangedEvent;
            m_commandBinding.VisibleChanged += this.HandleVisibleChangedEvent;
            m_commandBinding.SelectedChanged += this.HandleSelectedChangedEvent;
        }
    }

    /// <summary>
    /// Adapter osztály CommandBinding objektumok ToolStripMenuItem (vagyis menüelem) objektumokkal való
    /// összekötésére.
    /// </summary>
    public class ToolStripMenuItem_CommandBindingConnector : CommandBindingConnectorBase
    {
        private ToolStripMenuItem m_item;

        protected ToolStripMenuItem_CommandBindingConnector(ToolStripMenuItem item, CommandBinding commandBinding) : base(commandBinding)
        {
            m_item = item;
            m_item.Click += this.HandleUIEvent;
        }

        protected override void HandleEnableChangedEvent(object sender, CommandBinding.EnableChangedEventArgs e)
        {
            m_item.Enabled = e.IsEnabled;
        }

        protected override void HandleVisibleChangedEvent(object sender, CommandBinding.VisibleChangedEventArgs e)
        {
            m_item.Visible = e.IsVisible;
        }

        protected override void HandleSelectedChangedEvent(object sender, CommandBinding.SelectedChangedEventArgs e)
        {
            m_item.Checked = e.IsSelected;
        }

        private void HandleUIEvent(object sender, EventArgs e)
        {
            m_commandBinding.Execute();
        }

        /// <summary>
        /// Statikus metódus egy menüelem és egy commandBinding összekötésére.
        /// </summary>
        public static void Connect(ToolStripMenuItem item, CommandBinding commandBinding)
        {
            ToolStripMenuItem_CommandBindingConnector unused = new ToolStripMenuItem_CommandBindingConnector(item, commandBinding);
        }
    }

    /// <summary>
    /// Adapter osztály CommandBinding objektumok ToolStripButton (vagyis toolbar gomb) objektumokkal való
    /// összekötésére.
    /// </summary>
    public class ToolStripButton_CommandBindingConnector: CommandBindingConnectorBase
    {
        private readonly ToolStripButton toolStripButton;

        protected ToolStripButton_CommandBindingConnector(ToolStripButton button, CommandBinding commandBinding) : base(commandBinding)
        {
            toolStripButton = button;
            button.Click += this.HandleUIEvent;
        }

        protected override void HandleEnableChangedEvent(object sender, CommandBinding.EnableChangedEventArgs e)
        {
            toolStripButton.Enabled = e.IsEnabled;
        }

        protected override void HandleVisibleChangedEvent(object sender, CommandBinding.VisibleChangedEventArgs e)
        {
            toolStripButton.Visible = e.IsVisible;
        }

        protected override void HandleSelectedChangedEvent(object sender, CommandBinding.SelectedChangedEventArgs e)
        {
            toolStripButton.Checked = e.IsSelected;
        }

        private void HandleUIEvent(object sender, EventArgs e)
        {
            m_commandBinding.Execute();
        }
        /// <summary>
        /// Statikus metódus egy toolbar gomb és egy commandBinding összekötésére.
        /// </summary>
        public static void Connect(ToolStripButton button, CommandBinding commandBinding)
        {
            ToolStripButton_CommandBindingConnector unused = new ToolStripButton_CommandBindingConnector(button, commandBinding);
        }
    }

    #region ToolStripItem_CommandBindingConnector

    // Bevezethetnénk egy általános ToolStripItem connectort a külön ToolStripMenuItem_CommandBindingConnector
    // és ToolStripButton_CommandBindingConnector helyett.
    // Egy probléma van: a ToolStripItem-nek nincs Checked tulajdonsága, így a CommandBinding IsSelected 
    //  tulajdonságot nem tudjuk így megvalósítani.
    //
    //public class ToolStripItem_CommandBindingConnector : CommandBindingConnectorBase
    //{
    //    private ToolStripItem item;

    //    protected ToolStripItem_CommandBindingConnector(ToolStripMenuItem item, CommandBinding commandBinding) : base(commandBinding)
    //    {
    //        this.item = item;
    //        this.item.Click += this.HandleUIEvent;
    //    }

    //    protected override void HandleEnableChangedEvent(object sender, CommandBinding.EnableChangedEventArgs e)
    //    {
    //        item.Enabled = e.IsEnabled;
    //    }

    //    protected override void HandleVisibleChangedEvent(object sender, CommandBinding.VisibleChangedEventArgs e)
    //    {
    //        item.Visible = e.IsVisible;
    //    }

    //    protected override void HandleSelectedChangedEvent(object sender, CommandBinding.SelectedChangedEventArgs e)
    //    {
    //       throw new NotSupportedException("");
    //    }

    //    private void HandleUIEvent(object sender, EventArgs e)
    //    {
    //        m_commandBinding.Execute();
    //    }

    //    // Connect is a shared (static) method that performs the task of adapting a menu
    //    // item to a command.  The commander exists only to wire up the two objects -- 
    //    // it is not used further
    //    public static void Connect(ToolStripMenuItem item, CommandBinding commandBinding)
    //    {
    //        ToolStripItem_CommandBindingConnector unused = new ToolStripItem_CommandBindingConnector(item, commandBinding);
    //    }
    //}

    #endregion
}

