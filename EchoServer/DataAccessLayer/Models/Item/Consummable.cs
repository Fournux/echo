using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Consummable : Item
    {
        public int RequiredLevel {get; set;}
        public virtual ICollection<ConsummableCharacteristic> ConsummableCharacteristics {get; set;} = new List<ConsummableCharacteristic>();
      
    }
}