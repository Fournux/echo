using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public bool TargetRequired {get; set;}
        public virtual ICollection<ArchetypeSkill> ArchetypeSkills {get; set;}
        public virtual ICollection<SkillLevel> SkillLevels {get; set;} = new List<SkillLevel>();

    }
}