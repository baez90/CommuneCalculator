using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommuneCalculator.DB.Entities
{
    public class Roommate
    {
        [Key]
        public int RoommateId { get; set; }

        [Required, StringLength(30)]
        public string FirstName { get; set; }

        [Required, StringLength(30)]
        public string LastName { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime MoveInDate { get; set; } = DateTime.Today;

        [Column(TypeName = "datetime")]
        public DateTime? MoveOutDate { get; set; } = null;

        public virtual ICollection<AbsenceTime> AbsenceTimes { get; set; } = new List<AbsenceTime>();
    }
}