using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppFx.CommandBinding;
using DesignPatternApp.Commands;

namespace DesignPatternApp
{
    partial class App
    {
        public void NewDocument()
        {
            CloseDocument();

            document = new DrawingDocument();
            graphicsView = new GraphicsView();
            mainForm.SetLeftPanel(graphicsView);
            graphicsView.SetDocumentAndRegisterToDocEvents(document);
            infoPanel.SetDocumentAndRegisterToDocEvents(document);

            #region Documents
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.CloseDocument, true);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.SaveDocument, true);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.SaveAsDocument, true);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.ClearDocument, true);
            #endregion

            #region Tools
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.ClearDocument, true);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.Undo, false);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.NewRect, true);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.NewEllipse, true);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.SelectShape, true);
            #endregion

            // addTestData();
        }

        void addTestData()
        {
            document.CreateRect(new Rectangle(20, 100, 200, 100));
            document.CreateRect(new Rectangle(150, 70, 300, 50));
            document.CreateEllipse(new Rectangle(250, 300, 100, 100));

            document.SelectedShapeIndex = 1;
        }

        void showNotImplemented()
        {
            MessageBox.Show("Not implemented.");
        }

        public void OpenDocument()
        {
            showNotImplemented();
        }

        public void CloseDocument()
        {
            // Nincs dokumentum megnyitva
            if (document == null)
                return;

            graphicsView.RemoveDocumentAndUnregisterDocEvents();
            graphicsView.Dispose();
            infoPanel.RemoveDocumentAndUnregisterDocEvents();
            document = null;

            #region Documents
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.CloseDocument, false);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.SaveDocument, false);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.SaveAsDocument, false);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.ClearDocument, false);
            #endregion

            #region Tools
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.ClearDocument, false);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.Undo, false);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.NewRect, false);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.NewEllipse, false);
            CommandBindingManager.Instance.EnableCommandBinding(CommandName.SelectShape, false);
            #endregion
            commandProcessor.Clear();
        }

        public void SaveDocument()
        {
            showNotImplemented();
        }

        public void SaveAsDocument()
        {
            showNotImplemented();
        }


        #region Tools

        public void SelectShape()
        {
            showNotImplemented();
        }

        public void ClearDocument()
        {
            executeCommand(new ClearCommand());
        }

        public void UndoLast()
        {
            unexecuteLastCommand();
        }

        public void NewRect()
        {
            executeCommand(new NewRectCommand());
        }

        public void NewEllipse()
        {
            executeCommand(new NewEllipseCommand());
        }


        #endregion

    }
}
