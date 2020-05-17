using System;
using System.Collections.Generic;
using System.Text;

namespace Meres1
{
    public class HardDisk 
    {
        public HardDisk( int manufacturingYear, int _capacity, int _newPrice )
        {
            this.yearOfCreation = manufacturingYear;
            this.newPrice = _newPrice;
            this.capacityGB = _capacity;
        }

        int yearOfCreation;
        int capacityGB;
        int newPrice;

        public double GetPrice()
        {
            return yearOfCreation < ( DateTime.Today.Year - 4 ) ? 0 : newPrice - ( DateTime.Today.Year - yearOfCreation ) * 5000;
        }

        public int GetAge()
        {
            return DateTime.Today.Year - yearOfCreation;
        }

    }
}
