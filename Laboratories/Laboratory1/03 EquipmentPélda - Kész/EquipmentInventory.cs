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
                Console.WriteLine("Leírás: {0}\tÉletkor: {1}\tÉrtéke: {2}",
                   eq.GetDescription(), eq.GetAge(), eq.GetPrice());
            }
        }

        public void AddEquipment(IEquipment eq)
        {
            equipment.Add(eq);
        }

    }

}
