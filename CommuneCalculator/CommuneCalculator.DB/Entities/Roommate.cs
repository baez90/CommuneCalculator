using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CryptSharp;

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

        [Required, StringLength(30)]
        public string Login { get; set; }

        [StringLength(100)]
        public string PasswordHash { get; set; }

        public bool IsTreasurer { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime MoveInDate { get; set; } = DateTime.Today;

        [Column(TypeName = "datetime")]
        public DateTime? MoveOutDate { get; set; } = null;

        public virtual ICollection<AbsenceTime> AbsenceTimes { get; set; } = new List<AbsenceTime>();

        public bool ValidatePassword(string password)
        {
            return Crypter.CheckPassword(password, PasswordHash);
        }

        public bool UpdatePassword(string oldPassword, string newPassword)
        {
            if (!ValidatePassword(oldPassword)) return false;
            PasswordHash = Crypter.Blowfish.Crypt(newPassword);
            return true;
        }
    }
}