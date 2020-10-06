using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class NPC : Creature
    {
        public int MapId {get; set;}
        public virtual Map Map {get; set;}
        public int InitialX {get; set;}
        public int InitialY {get; set;}
        public int CanMove {get; set;}
    }
}