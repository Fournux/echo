using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public abstract class Quest
    {
        public int QuestId {get; set;}
        public int RequiredLevel {get; set;}
        public int? QuestMoney {get; set;}
        public int MinimumLevel {get; set;}
        public ICollection<QuestItem> QuestItems {get; set;} = new List<QuestItem>();
        public int QuestGroupId {get; set;}
        public virtual QuestGroup QuestGroup {get; set;}

    }
}