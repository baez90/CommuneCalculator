using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommuneCalculator.DB.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Index("IX_Category_Name", IsUnique = true), StringLength(30), Required]
        public string Name { get; set; }
    }
}