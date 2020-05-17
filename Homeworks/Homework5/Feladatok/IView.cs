using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Signals
{
    /// <summary>
    /// Az egyes nézetek közös interfésze. Nem lehet osztály, mert az egyes nézetek a UserControl-ból származnak
    /// és akkor View-val együtt már két ősük lenne.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Az implementáló feladata ebben a nézet frissítése, tipikusan a dokumentum aktuális 
        /// állapota alapján.
        /// </summary>
        void Update();
        /// <summary>
        /// A nézethez tartozó dokumentumot adja vissza.
        /// </summary>
        Document GetDocument();
        /// <summary>
        /// A dokumentumhoz tartozó nézet sorszáma. NET környezetben egy interfészben
        /// nem csak műveletek, hanem property-k és események is lehetnek (melyeket
        /// természetesen meg kell valósítani az implementáló osztályokban).
        /// </summary>
        int ViewNumber { get; set; }
    }
}
