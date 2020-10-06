

namespace DataAccessLayer.Models
{
    public class ConsummableCharacteristic
    {
        public int ItemId {get; set;}
        public virtual Consummable Consummable {get; set;}
        public int CharacteristicId {get; set;}
        public virtual Characteristic Characteristic {get; set;}
        public double Value {get; set;}
        public int? Duration {get; set;}
    }
}