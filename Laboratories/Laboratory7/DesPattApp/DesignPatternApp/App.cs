using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using AppFx.Command;
using AppFx.CommandBinding;

namespace DesignPatternApp
{
    public partial class App
    {
        #region Singleton

        static readonly App instance = new App();

        public static App Instance
        {
            get { return instance; }
        }

        private App()
        { }

        #endregion

        #region Fields
        /// <summary>
        /// Az alkalmazás főablaka
        /// </summary>
        private MainForm mainForm;

        private DrawingDocument document;
        private GraphicsView graphicsView;
        private InfoPanel infoPanel;
        readonly CommandProcessor commandProcessor = new CommandProcessor();

        #endregion

        public DrawingDocument Document
        {
            get { return document; }
        }
		
        public void Initialize(MainForm mainForm, InfoPanel infoPanel)
        {
            this.mainForm = mainForm;
            this.infoPanel = infoPanel;

            #region Documents
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.NewDocument, true);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.OpenDocument, true);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.CloseDocument, false);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.SaveDocument, false);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.SaveAsDocument, false);
            #endregion

            #region Tools
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.ClearDocument, false);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.Undo, false);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.NewRect, false);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.NewEllipse, false);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.SelectShape, false);
            #endregion
        }

            // Figyelmen kívül hagyja a kérést, ha a régi index megegyezik az újjal (nem süt el változás eseményt)
        public void SetSelectedShape(int shapeIndex)
        {
            if (document == null)
                return;
            document.SelectedShapeIndex = shapeIndex;
        }

        public void RemoveShape(int shapeID)
        {
            if (document == null)
                return;

            document.RemoveShape(shapeID);
        }

        public Rect CreateRandomRect()
        {
            return document.CreateRect(RandomHelper.GetRandomRect());
        }

        public Ellipse CreateRandomEllipse()
        {
            return document.CreateEllipse(RandomHelper.GetRandomRect());
        }

        void executeCommand(Command cmd)
        {
            commandProcessor.ExecuteCommand(cmd);
            CommandBindingManager.Instance.EnableCommandBinding(
            CommandName.Undo, commandProcessor.HasAny);
        }
        void unexecuteLastCommand()
        {
            commandProcessor.UnExecuteLastCommand();
            CommandBindingManager.Instance.EnableCommandBinding(
            CommandName.Undo, commandProcessor.HasAny);
        }
    }
}
