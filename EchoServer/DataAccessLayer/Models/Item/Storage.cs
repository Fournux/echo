using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Storage
    {
        public int StorageId {get; set;}
        public virtual ICollection<ItemInstance> ItemInstances {get; set;} = new List<ItemInstance>();
        public int Capacity {get; set;}
        public int Money {get; set;}
        public virtual Account Account {get; set;}
        public virtual Character Character {get; set;}
    }
}