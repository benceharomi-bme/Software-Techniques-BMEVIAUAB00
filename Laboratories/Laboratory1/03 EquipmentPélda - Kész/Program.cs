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

            // Amennyiben nem 2016 az aktu�lis �v, az al�bbi sorokn�l a 2016-os �vet
            // �rjuk �t az aktu�lis �vre, a 2015-�t pedig enn�l eggyel kisebb sz�mra !

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
