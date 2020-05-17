using System;
using System.Collections.Generic;
using System.Text;

namespace Equipment
{
    public interface IEquipment
    {
        double GetPrice();
        int GetAge();
        string GetDescription();
    }
}
