using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FontEditor
{
    public class App
    {
        private List<Document> documents;

        App()
        {
            throw new System.NotImplementedException();
        }

        public static App Instance
        {
            get => default;
            set
            {
            }
        }

        public Document ActiveDocument
        {
            get => default;
            set
            {
            }
        }

        public void CloseActiveDocument()
        {
            throw new System.NotImplementedException();
        }

        public void NewDocument()
        {
            throw new System.NotImplementedException();
        }

        public void OpenDocument()
        {
            throw new System.NotImplementedException();
        }

        public void SaveActiveDocument()
        {
            throw new System.NotImplementedException();
        }
    }
}