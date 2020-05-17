using System;
using System.Collections.Generic;
using System.Text;

namespace Equipment
{
    public class LedDisplay : DisplayBase, IEquipment
    {
        int responseTime;

        public LedDisplay(int yearOfCreation, int newPrice, int size, int responseTime)
        {
            this.manufacturingYear = yearOfCreation;
            this.price = newPrice;
            this.size = size;
            this.responseTime = responseTime;
        }

        public double GetPrice()
        {
            return this.price;
        }

        public int GetAge()
        {
            return DateTime.Today.Year - this.manufacturingYear;
        }

        public string GetDescription()
        {
            return "LedDisplay";
        }
    }

}
