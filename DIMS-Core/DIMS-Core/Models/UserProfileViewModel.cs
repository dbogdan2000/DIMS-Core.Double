using System;
using System.ComponentModel.DataAnnotations;
using DIMS_Core.BusinessLayer.Converters;
using DIMS_Core.Common.Enums;
using Newtonsoft.Json;

namespace DIMS_Core.Models
{
    /// <summary>
    ///     TODO: Task 18
    ///     You need to add serialization attributes from  Newtonsoft.Json package
    ///     https://www.newtonsoft.com/
    /// </summary>
    public class UserProfileViewModel
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 6)]
        // mark this field as `Name` by using Json Attribute
        public string FullName { get; set; }

        [Required]
        [JsonProperty("Your direction")]

        // TODO: Task 19
        // You need to review custom DirectionConverter realization
        [JsonConverter(typeof(DirectionConverter))]
        public int DirectionId { get; set; }

        [Required]
        public string Education { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        // mark this field as `Birth date` by using Json Attribute
        public DateTime? BirthDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        // mark this field as `Start date` by using Json Attribute
        public DateTime? StartDate { get; set; }

        [Required]
        // mark this field as `University average score` by using Json Attribute
        public double UniversityAverageScore { get; set; }

        [Required]
        // mark this field as `Math score` by using Json Attribute
        public double MathScore { get; set; }

        [Required]
        // mark this field as ignored by using Json Attribute
        public byte Sex { get; set; }

        [DataType(DataType.Text)]
        // mark this field as ignored by using Json Attribute
        public string Skype { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Roles Role { get; set; }

        [DataType(DataType.PhoneNumber)]
        // mark this field as `Mobile` by using Json Attribute
        public string MobilePhone { get; set; }
    }
}