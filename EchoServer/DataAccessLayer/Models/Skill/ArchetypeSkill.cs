using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class ArchetypeSkill
    {
        public int ArchetypeId {get; set;}
        public virtual Archetype Archetype {get; set;}
        public int SkillId { get; set; }
        public virtual Skill Skill {get; set;}

    }
}