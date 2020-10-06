using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class BaseLevel
    {
        public int LevelId { get; set; }
        public int ExpRequired { get; set; }
        public ICollection<Character> Characters {get; set;} = new List<Character>();
    }
}