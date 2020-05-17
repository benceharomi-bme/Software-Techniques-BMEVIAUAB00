using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFx.DocView
{
    public interface IView
    {
        // Esetünkben a dokumentumoknak különböző eseményei is lehetnek. Minden nézet 
        // a dokumentum azon eseményeire iratkozik fel, melyek számára érdekesek. Így
        // nem elég egy Update művelet bevezetése, mert annak hívásával a dokumentum csak egyfajta
        // eseményt/változást tudna jelezni. Helyette a nézeteknek implementálniuk kell az alábbi
        // SetDocumentAndRegisterToDocEvents műveletet, melyben egyrészt eltárolnak egy hivatkozást a 
        // dokumentumukra, másrészt felirítkoznak a számukra érdekes documentum eseményekre.  
        // void UpdateView();
        void SetDocumentAndRegisterToDocEvents(Document doc);
        void RemoveDocumentAndUnregisterDocEvents();
    }
}
