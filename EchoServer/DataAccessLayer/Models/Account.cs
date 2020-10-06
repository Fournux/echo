using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int StorageId {get; set;}
        public virtual Storage Storage {get; set;}
        public virtual ICollection<Character> Characters {get; set;} = new List<Character>();
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public bool Banned {get; set;} = false;
        
    }
}