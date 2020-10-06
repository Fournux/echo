using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public abstract class Equipment : Item
    {
        public int RequiredLevel {get; set;}
        public virtual ICollection<EquipmentCharacteristic> EquipmentCharacteristics {get; set;} = new List<EquipmentCharacteristic>();

    }
}