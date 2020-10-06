using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public abstract class Creature
    {
        public int CreatureId { get; set; }
        public string Name { get; set; }
        public int BaseLevelId {get; set;}
        public int HP {get; set;}
        public int SP {get; set;}
        public int AGI {get; set;}
        public int INT {get; set;}
        public int DEX {get; set;}
        public int STR {get; set;}
        public int VIT {get; set;}
        public int LUK {get; set;}
        public int ATK {get; set;}
        public int DEF {get; set;}
        public int MATK {get; set;}
        public double ASPD {get; set;}
        public double MSPD {get; set;}
        public int HIT {get; set;}
        public int FLEE {get; set;}
        public int CRIT {get; set;}
        public int ArchetypeId {get; set;}
        public virtual Archetype Archetype {get; set;}

    }
}