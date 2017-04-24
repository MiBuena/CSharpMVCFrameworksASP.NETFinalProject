using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.BidningModels
{
    public class AddressBindingModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string City { get; set; }

        [MinLength(2)]
        [MaxLength(200)]
        public string District { get; set; }

        [MinLength(1)]
        [MaxLength(20)]
        public string BlockNumber { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string Entrance { get; set; }

        [MinLength(1)]
        [MaxLength(20)]
        public string AppartmentNumber { get; set; }

        [MinLength(2)]
        [MaxLength(70)]
        public string Street { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string StreetNumber { get; set; }

    }
}
