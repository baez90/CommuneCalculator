using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommuneCalculator.DB.Entities
{
    public class Purchase
    {
        [Key]
        public int ReceiptId { get; set; }

        public decimal Amount { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public virtual Category Category { get; set; }

        public virtual Shop Shop { get; set; }
    }
}