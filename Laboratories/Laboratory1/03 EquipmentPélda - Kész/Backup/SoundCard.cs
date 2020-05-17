using System;
using System.Collections.Generic;
using System.Text;

namespace Meres1
{
    public class SoundCard
    {
        public SoundCard( int manufacturingYear, int _newPrice )
        {
            this.yearOfCreation = manufacturingYear;
            this.newPrice = _newPrice;
        }

        int yearOfCreation;
        int newPrice;

        public double GetPrice()
        {
            return yearOfCreation < ( DateTime.Today.Year - 4 ) ? 0 : newPrice - ( DateTime.Today.Year - yearOfCreation) * 2000;
        }

        public int GetAge()
        {
            return DateTime.Today.Year - yearOfCreation;
        }

    }
}
