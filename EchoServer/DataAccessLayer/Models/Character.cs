using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Character : Creature
    {
        public int MapId {get; set;}
        public virtual Map Map {get; set;}
        public int PositionX {get; set;}
        public int PositionY {get; set;}
        public virtual BaseLevel BaseLevel {get; set;}
        public int JobLevelId {get; set;}
        public virtual JobLevel JobLevel {get; set;}
        public int StatusPoints {get; set;}
        public int SkillPoints {get; set;}
        public int StorageId {get; set;}
        public virtual Storage Storage {get; set;}
        public int AccountId {get; set;}
        public virtual Account Account {get; set;}
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime? LatestConnectionDate {get; set;}

    }
}