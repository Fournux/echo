using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class CreatureSkill
    {
        public int CreatureId {get; set;}
        public virtual Creature Creature {get; set;}
        public int SkillId { get; set; }
        public virtual Skill Skill {get; set;}
        public int Level {get; set;}
    }
}