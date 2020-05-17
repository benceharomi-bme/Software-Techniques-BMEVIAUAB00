using System;
using System.Collections.Generic;
using System.Text;

namespace Equipment
{
    public class EquipmentInventory
    {
        private List<IEquipment> equipment;

        public EquipmentInventory()
        {
            this.equipment = new List<IEquipment>();
        }


        public void ListAll()
        {
            foreach (IEquipment eq in equipment)
            {
                Console.WriteLine("Le�r�s: {0}\t�letkor: {1}\t�rt�ke: {2}",
                   eq.GetDescription(), eq.GetAge(), eq.GetPrice());
            }
        }

        public void AddEquipment(IEquipment eq)
        {
            equipment.Add(eq);
        }

    }

}
