using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class MonsterItem
    {
        public int CreatureId {get; set;}
        public virtual Monster Monster {get; set;}
        public int ItemId {get; set;}
        public virtual Item Item {get; set;}
        public double Percentage {get; set;}

    }
}