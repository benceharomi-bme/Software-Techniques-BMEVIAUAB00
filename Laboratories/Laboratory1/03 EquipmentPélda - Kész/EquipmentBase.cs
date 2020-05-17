using System;
using System.Collections.Generic;
using System.Text;

namespace Equipment
{
    public abstract class EquipmentBase : IEquipment
    {
        protected int yearOfCreation;
        protected int newPrice;

        public EquipmentBase(int yearOfCreation, int newPrice)
        {
            this.yearOfCreation = yearOfCreation;
            this.newPrice = newPrice;
        }

        public int GetAge()
        {
            return DateTime.Today.Year - yearOfCreation;
        }

        public abstract double GetPrice();

        public virtual string GetDescription()
        {
            return "EquipmentBase";
        }
    }
}