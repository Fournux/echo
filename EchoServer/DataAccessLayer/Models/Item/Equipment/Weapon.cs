using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Weapon : Equipment
    { 
        public int Range {get; set;}
        public bool SingleHand {get; set;}
    }
}
