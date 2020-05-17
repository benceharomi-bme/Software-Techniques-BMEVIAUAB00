using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FontEditor
{
    public abstract class Document
    {
        private List<IView> views;

        public string Name
        {
            get => default;
            set
            {
            }
        }

        public string Path
        {
            get => default;
            set
            {
            }
        }

        public void AttachView(IView view)
        {
            throw new System.NotImplementedException();
        }

        public abstract void LoadDocument(string path);

        public abstract void SaveDocument();

        public void UpdateAllViews()
        {
            throw new System.NotImplementedException();
        }
    }
}