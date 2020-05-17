using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FontEditor
{
    public class FontEditorView : IView
    {
        private char editedChar;
        private double zoom;

        private FontEditorDocument document;

        public void Draw(Graphics g)
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}