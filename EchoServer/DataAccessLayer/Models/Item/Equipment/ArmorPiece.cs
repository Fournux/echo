using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class ArmorPiece : Equipment
    {
        public int ArmorPieceCategoryId {get; set;}
        public virtual ArmorPieceCategory ArmorPieceCategory {get; set;}
    }
}