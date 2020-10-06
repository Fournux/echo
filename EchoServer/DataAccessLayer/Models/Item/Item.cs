
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public abstract class Item
    {
        public int ItemId {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public int Weight {get; set;}
        public virtual ICollection<MonsterItem> MonsterItems {get; set;} = new List<MonsterItem>();
        public virtual ICollection<ItemInstance> ItemInstances {get; set;} = new List<ItemInstance>();
        public virtual ICollection<CollectionQuestItem> CollectionQuestItems {get; set;} = new List<CollectionQuestItem>();
        public virtual ICollection<QuestItem> QuestItems {get; set;} = new List<QuestItem>();


    }
}