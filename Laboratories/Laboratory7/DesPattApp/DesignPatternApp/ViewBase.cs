using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppFx.DocView;

namespace DesignPatternApp
{
    /// <summary>
    /// -	A nézeteink közös ősosztálya, kóduplikáció elkerülésére vezettük be. Implementálja az IView interfészt.
    /// -   UserControl-ból származik(hasonló koncepciót már láttunk a megelőző gyakorlat FontEditor példájában)
    /// -	A document tagváltozóban tárolja a nézetet.
    /// -	A dokumentum megfelelő eseményeire való fel/leiratkozáshoz bevezeti a RegisterToDocEvents 
    ///     és UnRegisterToDocEvents virtuális műveleteket, a leszármazottakban igény szerint lehet implementálni
    /// </summary>
    public partial class ViewBase : UserControl, IView
    {
        protected DrawingDocument document;

        public ViewBase()
        {
            InitializeComponent();
        }

        public void SetDocumentAndRegisterToDocEvents(Document document)
        {
            this.document = (DrawingDocument)document;
            RegisterToDocEvents();
        }

        public void RemoveDocumentAndUnregisterDocEvents()
        {
            // Fontos a sorrend
            UnRegisterToDocEvents();
            this.document = null;
        }

        protected virtual void RegisterToDocEvents()
        { }

        protected virtual void UnRegisterToDocEvents()
        { }


    }
}
