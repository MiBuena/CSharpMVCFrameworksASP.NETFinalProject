using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.EntityModels
{
    public class Address
    {
        public int Id { get; set; }

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

        [MinLength(1)]
        [MaxLength(20)]
        public string Entrance { get; set; }

        [MinLength(1)]
        [MaxLength(20)]
        public string AppartmentNumber { get; set; }

        [MinLength(2)]
        [MaxLength(70)]
        public string Street { get; set; }

        [MinLength(1)]
        [MaxLength(20)]
        public string StreetNumber { get; set; }

        public override string ToString()
        {
            string address = null;

            if (this.District != null)
            {
                address += $"{this.District} Distr.";
            }

            if (this.StreetNumber != null)
            {
                address += $", {this.StreetNumber}";
            }

            if (this.Street != null)
            {
                address += $" {this.Street} Str.";
            }

            if (this.BlockNumber != null)
            {
                address += $", {this.BlockNumber} Bl.";
            }

            if (this.Entrance != null)
            {
                address += $", {this.Entrance} Entr.";
            }

            if (this.AppartmentNumber != null)
            {
                address += $", {this.Entrance} App.";
            }

            return address;
        }
    }
}
