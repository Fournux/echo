using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Map
    {
        public int MapId {get; set;}
        public string MapCode {get; set;}
        public string Name {get; set;}
        public virtual ICollection<NPC> NPCs {get; set;} = new List<NPC>();
        public virtual ICollection<Character> Characters {get; set;} = new List<Character>();

    }
}