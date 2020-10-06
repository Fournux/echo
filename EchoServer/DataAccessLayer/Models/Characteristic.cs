using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Characteristic
    {
        public int CharacteristicId {get; set;}
        public string CharacteristicCode {get; set;}
        public ICollection<EquipmentCharacteristic> EquipmentCharacteristics {get; set;} = new List<EquipmentCharacteristic>();
        public ICollection<ConsummableCharacteristic> ConsummableCharacteristics {get; set;} = new List<ConsummableCharacteristic>();

    }
}