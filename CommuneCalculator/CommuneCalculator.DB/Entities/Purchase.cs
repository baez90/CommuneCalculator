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
        
        public int CategoryRefId { get; set; }

        [ForeignKey(nameof(CategoryRefId))]
        public virtual Category Category { get; set; }
        
        public int ShopRefId { get; set; }

        [ForeignKey(nameof(ShopRefId))]
        public virtual Shop Shop { get; set; }
        
        public int PurchasedByRefId { get; set; }

        [ForeignKey(nameof(PurchasedByRefId))]
        public virtual Roommate PurchasedBy { get; set; }
    }
}