using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class QuestGroup
    {
        public int QuestGroupId {get; set;}
        public int MinimumLevel {get; set;}
        public string Name {get; set;}

        public virtual ICollection<Quest> Quests {get; set;} = new List<Quest>();



    }
}