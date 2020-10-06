using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class ItemInstance
    {
        public int ItemInstanceId {get; set;}
        public int ItemId {get; set;}
        public virtual Item Item {get; set;}
        public int? StorageId {get; set;}
        public virtual Storage Storage {get; set;}
        public int Index {get; set;}
        public DateTime CreationDate {get; set;}
        public int Quantity {get; set;} = 1;
        public int? UpgradeLevel {get; set;}

    }
}