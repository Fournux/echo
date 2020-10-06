using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class HuntingQuestMonster
    {
        public int QuestId {get; set;}
        public virtual HuntingQuest HuntingQuest {get; set;}
        public int MonsterId {get; set;}
        public virtual Monster Monster {get; set;}
        public int Number {get; set;}
    }
}