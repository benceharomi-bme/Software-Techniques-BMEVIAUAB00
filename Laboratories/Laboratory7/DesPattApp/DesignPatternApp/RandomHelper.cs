using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternApp
{
    static  class RandomHelper
    {
        static Random rand = new Random();

        /// <summary>
        /// Visszaad egy random számot, ami alakzatok létrehozásánál használható paraméterezésre.
        /// </summary>
        static int getRandomValue()
        {
            return rand.Next(20, 250);
        }

        public static Rectangle GetRandomRect()
        {
            return new Rectangle(getRandomValue(), getRandomValue(), getRandomValue(), getRandomValue());
        }
    }
}
