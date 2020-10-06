using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class ArmorPieceCategory
    {
        public int ArmorPieceCategoryId {get; set;}
        public string Label {get; set;}
        public ICollection<ArmorPiece> ArmorPieces {get; set;} = new List<ArmorPiece>();
    }
}