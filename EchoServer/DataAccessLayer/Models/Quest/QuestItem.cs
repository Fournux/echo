using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class QuestItem
    {
        public int QuestId {get; set;}
        public virtual Quest Quest {get; set;}
        public int ItemId {get; set;}
        public virtual Item Item {get; set;}
        public int Quantity {get; set;}
    }
}