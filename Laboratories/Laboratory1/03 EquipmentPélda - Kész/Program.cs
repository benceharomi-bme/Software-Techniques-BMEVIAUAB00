using System;
using System.Collections.Generic;
using System.Text;

namespace Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            EquipmentInventory ei = new EquipmentInventory();

            // Amennyiben nem 2016 az aktuális év, az alábbi soroknál a 2016-os évet
            // írjuk át az aktuális évre, a 2015-öt pedig ennél eggyel kisebb számra !

            ei.AddEquipment(new HardDisk(2016, 30000, 80));
            ei.AddEquipment(new HardDisk(2015, 25000, 120));
            ei.AddEquipment(new HardDisk(2015, 25000, 250));

            ei.AddEquipment(new SoundCard(2016, 8000));
            ei.AddEquipment(new SoundCard(2015, 7000));
            ei.AddEquipment(new SoundCard(2015, 6000));

            ei.AddEquipment(new LedDisplay(2015, 80000, 17, 16));
            ei.AddEquipment(new LedDisplay(2016, 70000, 17, 12));

            ei.ListAll();

            Console.ReadKey();
        }

    }
}
