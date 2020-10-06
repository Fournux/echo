using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class CollectionQuestItem
    {
        public int QuestId {get; set;}
        public virtual CollectionQuest CollectionQuest {get; set;}
        public int ItemId {get; set;}
        public virtual Item Item {get; set;}
        public int Quantity {get; set;}
    }
}