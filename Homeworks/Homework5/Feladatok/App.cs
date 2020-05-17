using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Signals
{
    /// <summary>
    /// Az alkalmazást reprezentálja. Egy példányt kell létrehozni belőle az Initialize 
    /// hívásával, ez lesz a "gyökérobjektum". Ez bármely osztály számára hozzáférhető az
    /// App.Instance propertyn keresztül.
    /// </summary>
    public class App
    {
        /// <summary>
        /// Az aktív nézet (melynek tabfüle ki van választva).
        /// </summary>
        private IView activeView;
        /// <summary>
        /// Az alkalmazáshoz tartozó dokumentumok listája.
        /// </summary>
        private List<Document> documents = new List<Document>();
        /// <summary>
        /// A főablakot tárolja.
        /// </summary>
        private MainForm mainForm;
        /// <summary>
        /// Az alkalmazásobjektum tárolására szolgál. 
        /// </summary>
        private static App theApp;
        /// <summary>
        /// Elérhetővé teszi mindenki számára az alkalmazásobjektumot (App.Instance-ként
        /// érhető el.)
        /// </summary>
        public static App Instance
        {
            get { return theApp; }
        }
        /// <summary>
        /// Létrehozza az alkalmazásobjektumot.
        /// </summary>
        public static void Initialize(MainForm form)
        {
            theApp = new App();
            theApp.mainForm = form;
        }
        /// <summary>
        /// A főablak.
        /// </summary>
        public MainForm MainForm
        {
            get { return mainForm; }
        }

        /// <summary>
        /// Visszaadja az aktív dokumentumot.
        /// </summary>
        /// <returns></returns>
        public Document ActiveDocument
        {
            get 
            {
                if (activeView == null)
                    return null;

                return activeView.GetDocument();
            }
        }
        
        /// <summary>
        /// Bezárja az aktív dokumentumot.
        /// </summary>
        public void CloseActiveView()
        {
            if (mainForm.TabControl.TabPages.Count == 0)
                return;

            Document docToClose = ActiveDocument;

            // Eltávolítjuk a nézetet a dokumentum nézet listájából
            docToClose.DetachView(activeView);
            // Bezárjuk a view szülő tabját
            mainForm.TabControl.TabPages.Remove(getTabPageForView(activeView));

            // Ha ez volt a dokumentum utolsó nézete, akkor a dokumentumot is bezárjuk, eltávolítjuk a 
            // documents listából.
            if (!docToClose.HasAnyView())
                documents.Remove(docToClose);
        }

        /// <summary>
        /// Létrehoz egy új dokumentumot a hozzá tartozó nézettel.
        /// </summary>
        public void NewDocument()
        {
            // Bekérdezzük az új font típus (dokumentum) nevét a felhasználótól egy modális dialógs ablakban.
            NewDocForm form = new NewDocForm();
            if (form.ShowDialog() != DialogResult.OK)
                return;

            // Új dokumentum objektum létrehozása és felvétele a dokumentum listába.
            // TODO: ne a Document-et példányosítsuk, hanem a leszármazottunkat
            SignalDocument doc = new SignalDocument(form.DocName); 
            documents.Add(doc);
            createView(doc, true);
        }

        /// <summary>
        /// Frissíti az activeDocument változót, hogy az aktuálisan kiválasztott tabhoz tartozó dokumentumra 
        /// mutasson.
        /// </summary>
        public void UpdateActiveView()
        {
            if (mainForm.TabControl.TabPages.Count == 0)
                activeView = null;
            else
                activeView = (IView)mainForm.TabControl.SelectedTab.Tag;
        }

        /// <summary>
        /// Létrehoz egy új nézetet az aktív dokumentumhoz.
        /// </summary>
        public void CreateViewForActiveDocument()
        {
            Document doc = ActiveDocument;
            if (doc == null)
                return;
            createView(doc, true);
        }

        /// <summary>
        /// Megnyit egy dokumentumot. Nincs implementálva.
        /// </summary>
        public void OpenDocument()
        {
            // 1. Fájl útvonal megkérdezése a felhasználótól (OpenFileDialog).
            // http://msdn.microsoft.com/en-us/library/system.windows.forms.openfiledialog.aspx
            // Lényeges, hogy az MSDN-ben látható példával ellentétben NE nyissuk meg a fájlt
            // a dialóguson OpenFile hívásával, helyette egyszerűen a FileName property 
            // segítségével kérdezzük le a felhasználó által megadott útvonalat (amennyiben
            // a felhasználó az OK-kal zárta be az ablakot).
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            // Ha a felhasználó nem az OK gommbal zárta be az ablakot,
            // nem csinálunk semmit (visszatérünk)
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            // A felhasznalo altal megadott utvonal
            string path = openFileDialog.FileName;

            // 2. Új dokumentum objektum létrehozása, regisztrálása, nézet létrehozása, stb.
            // , a NewDocument művelet szolgálhat mintaként. 
            // A dokumentum neve a fájl neve legyen a könyvtár nélkül (ehhez használja a 
            // System.IO.Path osztály GetFileName statikus függvényét)
            string name = System.IO.Path.GetFileName(path);
            // A dokumentum letrehozasa
            SignalDocument doc = new SignalDocument(name);
            //A dokumentum regisztralasa
            documents.Add(doc);
            // A nezet letrehozasa
            createView(doc, true);

            // 3. Dokumentumba adatok betöltése (LoadDocument hívása  dokumentum objektumon)
            doc.LoadDocument(path);

            // 4. Nézetek értesítése, hogy frissítsék magukat.
            // Megjegyzés. Erre alapvetően a dokumentum osztály UpdateAllViews művelete használandó.
            // Ez viszont  protected , itt nem elérhető. Ne  tegye publikussá! Helyette kövesse
            // az egységbezárás alapelvét: az előző, 3. lépésben meghívta a SignalDocument.LoadDocument
            // műveletét. Tegye az UpdateAllViews hívást a LoadDocument végére. A Document-View
            // architektúrának ez az egyik lényegi pontja: minden dokumentum módosító művelet végére
            // oda kell tenni az UpdateAllViews hívást, hogy a nézetek tükrözzék a változásokat.
        }

        /// <summary>
        /// Elmenti az aktív dokumentum tartalmát. Nincs implementálva.
        /// </summary>
        public void SaveActiveDocument()
        {
            if (ActiveDocument == null)
                return;

            // Útvonal bekérése a felhasználótól a SaveFileDialog segítségével.
            // http://msdn.microsoft.com/en-us/library/system.windows.forms.savefiledialog.aspx
            // ..
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // Megjelenítés előtt paramlterezzük fel a dialógus ablakot
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;

            // Modálisan megjelenítjük a dialógusablakot.
            // Ha a felhasználó nem az OK gommbal zárta be az ablakot,
            // nem csinálunk semmit (visszatérünk)
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string path = saveFileDialog.FileName;

            // A dokumentum adatainak elmentése.
            ActiveDocument.SaveDocument(path);
        }

        /// <summary>
        /// Létrehoz egy új nézetet dokumentumhoz, és ezt be is regisztrálja a 
        /// dokumentumnál (hogy a jövőben étesüljön a változásairól). Egy új tabfület 
        /// is létrehoz a nézetnek.
        /// </summary>
        IView createView(Document doc, bool activateView)
        {
            // Új tab felvétele: az első paraméter egy kulcs, a második a tab felirata
            //mainForm.TabControl.TabPages.Add(form.DocName, form.DocName);
            TabPage tp = new TabPage(doc.Name);
            mainForm.TabControl.TabPages.Add(tp);
            GraphicsSignalView view = new GraphicsSignalView((SignalDocument)doc);
            //TabPage tp = mainForm.TabControl.TabPages[form.DocName];
            tp.Controls.Add(view);
            tp.Tag = view;
            view.Dock = DockStyle.Fill;

            // A View beregisztrálása a dokumentumnál, hogy értesüljön majd a dokumentum változásairól.
            doc.AttachView(view);

            // Ha az új nézet nem a dokumentum első nézete, akkor a tabfülön a nézet sorszámát is
            // megjelenítjük.
            if (view.ViewNumber > 1)
                tp.Text = tp.Text + ":" + view.ViewNumber;

            // Az új tab legyen a kiválasztott. 
            if (activateView)
            {
                mainForm.TabControl.SelectTab(tp); // Ennek hatására elsül a tab SelectedIndexChanged eseménykezelője, ami meg beállítja az activeView tagváltozót
                activeView = view;
            }
            return view;
        }

        /// <summary>
        /// Visszaadja az adott nézetet tartalmazó TabPage vezérlőt.
        /// Exception-t dob, ha nem találja.
        /// </summary>
        TabPage getTabPageForView(IView view)
        {
            foreach (TabPage page in mainForm.TabControl.TabPages)
               if (page.Tag == activeView)
                   return page;
            throw new Exception("Page for view not found.");
        }

    }
}
