using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class HuntingQuest : Quest
    {
        public virtual ICollection<HuntingQuestMonster> HuntingQuestMonsters {get; set;} = new List<HuntingQuestMonster>();
    }
}