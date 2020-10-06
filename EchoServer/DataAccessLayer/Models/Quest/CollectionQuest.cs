using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class CollectionQuest : Quest
    {
        public virtual ICollection<CollectionQuestItem> CollectionQuestItems {get; set;} = new List<CollectionQuestItem>();
    }
}