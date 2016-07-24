using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommuneCalculator.DB.Entities
{
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }

        [Required, StringLength(30)]
        public string ShopName { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}