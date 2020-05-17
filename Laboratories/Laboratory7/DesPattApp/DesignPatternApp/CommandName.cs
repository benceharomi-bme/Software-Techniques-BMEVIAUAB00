using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternApp
{
    static class CommandName
    {
        public const string NewDocument = "NewDoc";
        public const string OpenDocument = "OpenDoc";
        public const string CloseDocument = "CloseDoc";
        public const string SaveDocument = "SaveDoc";
        public const string SaveAsDocument = "SaveAsDoc";
        public const string ClearDocument = "ClearDoc";
        public const string Undo = "Undo";
        public const string NewRect = "NewRect";
        public const string NewEllipse = "NewEllipse";
        public const string SelectShape = "SelectShape";
    }
}
