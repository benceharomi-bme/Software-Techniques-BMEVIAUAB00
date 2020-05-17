using System;
using System.Collections.Generic;
using System.Text;

namespace Equipment
{
    public class SoundCard : EquipmentBase
    {
        public SoundCard(int yearOfCreation, int newPrice):
            base(yearOfCreation, newPrice)
        {

        }

        public override double GetPrice()
        {
            return yearOfCreation < (DateTime.Today.Year - 4) ? 0 : newPrice - (DateTime.Today.Year - yearOfCreation) * 2000;
        }

        public override string GetDescription()
        {
            return "SoundCard";
        }
    }
}
