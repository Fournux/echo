using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class SkillLevel
    {
        public int SkillId { get; set; }
        public virtual Skill Skill {get; set;}
        public int Level { get; set; }
        public int SpCost {get; set;}
        public int Range {get; set;}
        public float Cooldown {get; set;}
        public int EffectValue {get; set;}

    }
}