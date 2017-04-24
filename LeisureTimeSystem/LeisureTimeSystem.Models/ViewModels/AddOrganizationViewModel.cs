using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels
{
    public class AddOrganizationViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(3000)]
        public string Description { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string City { get; set; }

        [MinLength(2)]
        [MaxLength(200)]
        public string District { get; set; }

        [MinLength(1)]
        [MaxLength(20)]
        [Display(Name = "Block number")]
        public string BlockNumber { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string Entrance { get; set; }

        [MinLength(1)]
        [MaxLength(20)]
        [Display(Name = "Appartment number")]
        public string AppartmentNumber { get; set; }

        [MinLength(2)]
        [MaxLength(70)]
        public string Street { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        [Display(Name = "Street number")]
        public string StreetNumber { get; set; }

        [Url]
        [MinLength(2)]
        [MaxLength(500)]
        public string Website { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        public string Telephones { get; set; }
    }
}
