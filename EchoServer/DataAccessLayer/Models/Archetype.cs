using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Archetype
    {
        public int ArchetypeId { get; set; }
        public string Name { get; set; }
        public int MaximumJobLevel {get; set;}
        public int MinimumJobLevel {get; set;}

        public virtual ICollection<ArchetypeSkill> ArchetypeSkills {get; set;} = new List<ArchetypeSkill>();
        public virtual ICollection<Creature> Creatures {get; set;} = new List<Creature>();

    }
}