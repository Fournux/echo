using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Monster : Creature
    {
        public int MonsterId {get; set;}
        public virtual ICollection<MonsterItem> MonsterItems {get; set;} = new List<MonsterItem>();
        public virtual ICollection<HuntingQuestMonster> HuntingQuestMonsters {get; set;} = new List<HuntingQuestMonster>();
        public int BaseExp {get; set;}
        public int JobExp {get; set;}
        public bool Aggressive {get; set;}
        public bool CanMove {get; set;}
        public double Range {get; set;}
        public bool Looter {get; set;}

    }
}