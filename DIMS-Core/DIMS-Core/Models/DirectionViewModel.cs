using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS_Core.Models
{
    public class DirectionViewModel
    {
        public int DirectionId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string Description { get; set; }
    }
}
