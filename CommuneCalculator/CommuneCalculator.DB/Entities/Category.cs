using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommuneCalculator.DB.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; }
    }
}