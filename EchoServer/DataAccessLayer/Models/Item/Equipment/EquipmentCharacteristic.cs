

namespace DataAccessLayer.Models
{
    public class EquipmentCharacteristic
    {
        public int ItemId {get; set;}
        public virtual Equipment Equipment {get; set;}
        public int CharacteristicId {get; set;}
        public virtual Characteristic Characteristic {get; set;}
        public int Value {get; set;}
    }
}