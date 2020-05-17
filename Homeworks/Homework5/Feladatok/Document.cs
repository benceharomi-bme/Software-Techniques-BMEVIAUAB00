using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Signals
{
    /// <summary>
    /// Az egyes dokumentum típusok ősosztálya. Bár esetünkben csak egy dokumentum típus
    /// létezik, a későbbi bővíthetőség miatt célszerű külön választani.
    /// Tartalmazza a nézetek listáját, melyek a dokumentumot megjelenítik. 
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Lásd Name property.
        /// </summary>
        private string name;

        /// <summary>
        /// A nézetek listája, melyek a dokumentumot megjelenítik. 
        /// </summary>
        List<IView> views = new List<IView>();

        /// <summary>
        /// A dokumentumhoz tartozó nézetek száma.
        /// </summary>
        private int viewCount;

        /// <summary>
        /// A dokumentum neve. A FontEditorDocument esetén amit a felhasználó megad, tipikusan
        /// a betűtípus nevét fogja megadni.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// A dokumentumhoz tartozó nézetek száma.
        /// </summary>
        public int ViewCount
        {
            get { return viewCount; }
        }


        public Document(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Egy nézetet beregisztrál a dokumentumhoz.
        /// </summary>
        /// <param name="v"></param>
        public void AttachView(IView v)
        {
            views.Add(v);
            viewCount++;
            v.ViewNumber = viewCount;
            v.Update();
        }

        /// <summary>
        /// Kiregisztrál egy nézetet.
        /// </summary>
        /// <param name="v"></param>
        public void DetachView(IView v)
        {
            views.Remove(v);
            viewCount--;
        }

        public bool HasAnyView()
        {
            return views.Count > 0;
        }
        
        /// <summary>
        /// Frissíti az összes, dokumentumhoz tartozó nézetet.
        /// </summary>
        protected void UpdateAllViews()
        {
            foreach (IView view in views)
                view.Update();
        }

        /// <summary>
        /// Betölti a dokumentum tartalmát. A leszármazott osztályban felüldefiniálandó (override).
        /// </summary>
        public virtual void LoadDocument(string filePath)
        { }

        /// <summary>
        /// Elmenti a dokumentum tartalmát. A leszármazott osztályban felüldefiniálandó (override).
        /// </summary>
        public virtual void SaveDocument(string filePath)
        { }
    }
}
