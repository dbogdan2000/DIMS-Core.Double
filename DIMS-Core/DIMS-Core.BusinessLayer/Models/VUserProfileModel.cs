using System;
using DIMS_Core.Common.Enums;

namespace DIMS_Core.BusinessLayer.Models
{
    public class VUserProfileModel
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Direction { get; set; }

        public SexType Sex { get; set; }

        public string Education { get; set; }

        public int? Age { get; set; }

        public double UniversityAverageScore { get; set; }

        public double MathScore { get; set; }

        public string Address { get; set; }

        public string MobilePhone { get; set; }

        public string Skype { get; set; }

        public DateTime? StartDate { get; set; }
    }
}
