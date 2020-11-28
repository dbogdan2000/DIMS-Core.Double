using DIMS_Core.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DIMS_Core.Models
{
    public class UserProfileViewModel
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 6)]
        public string FullName { get; set; }

        [Required]
        public int DirectionId { get; set; }

        [Required]
        public string Education { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Required]
        public double UniversityAverageScore { get; set; }

        [Required]
        public double MathScore { get; set; }

        [Required]
        public byte Sex { get; set; }

        [DataType(DataType.Text)]
        public string Skype { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Roles Role { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }
    }
}
