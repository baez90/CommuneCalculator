using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommuneCalculator.DB.Entities
{
    public class AbsenceTime
    {
        [Key]
        public int AbsenceId { get; set; }

        [Required, StringLength(100)]
        public string Reason { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime AbsenceStart { get; set; } = DateTime.Today;

        [Column(TypeName = "datetime")]
        public DateTime AbsenceEnd { get; set; } = DateTime.Today.AddMonths(1);

        [Required]
        public virtual Roommate Roommate { get; set; }
    }
}