using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFx.CommandBinding
{
    public class CommandBinding
    {
        public delegate void EnableChangedEventHandler(object sender, CommandBinding.EnableChangedEventArgs e);
        public delegate void VisibleChangedEventHandler(object sender, CommandBinding.VisibleChangedEventArgs e);
        public delegate void SelectedChangedEventHandler(object sender, CommandBinding.SelectedChangedEventArgs e);
        public delegate void Action();

        public event EnableChangedEventHandler EnableChanged;
        public event VisibleChangedEventHandler VisibleChanged;
        public event SelectedChangedEventHandler SelectedChanged;

        private bool isEnabled = true;
        private bool isVisible = true;
        private bool isSelected = true;

        private readonly Action action;

        public CommandBinding(Action action)
        {
            this.action = action;
        }

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }

            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    if (EnableChanged != null)
                    {
                        EnableChanged(this, new EnableChangedEventArgs(IsEnabled));
                    }
                }
            }
        }

        public bool IsVisible
        {
            get
            {
                return isVisible;
            }

            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    if (VisibleChanged != null)
                    {
                        VisibleChanged(this, new VisibleChangedEventArgs(IsVisible));
                    }
                }
            }
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    if (SelectedChanged != null)
                    {
                        SelectedChanged(this, new SelectedChangedEventArgs(IsSelected));
                    }
                }
            }
        }

        // Default viselkedés, a leszármazottban felül lehet definiálni
        public virtual void Execute()
        {
            action();
        }


        public class EnableChangedEventArgs : EventArgs
        {
            public bool IsEnabled { get; private set; }

            public EnableChangedEventArgs(bool isEnabled)
            {
                this.IsEnabled = isEnabled;
            }
        }

        public class VisibleChangedEventArgs : EventArgs
        {
            public bool IsVisible { get; private set; }

            public VisibleChangedEventArgs(bool isEnabled)
            {
                this.IsVisible = isEnabled;
            }
        }

        public class SelectedChangedEventArgs : EventArgs
        {
            public bool IsSelected { get; private set; }

            public SelectedChangedEventArgs(bool isSelected)
            {
                this.IsSelected = isSelected;
            }
        }
    }
}
