using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommuneCalculator.DB.Entities
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }

        public decimal Amount { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime PurchaseDate { get; set; } = DateTime.Today;
        
        public virtual Category Category { get; set; }
        
        public virtual Shop Shop { get; set; }
        
        public virtual Roommate PurchasedBy { get; set; }
    }
}