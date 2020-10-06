using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class JobLevel
    {
        public int LevelId { get; set; }
        public int ExpRequired { get; set; }
        public ICollection<Character> Characters {get; set;} = new List<Character>();
    }
}