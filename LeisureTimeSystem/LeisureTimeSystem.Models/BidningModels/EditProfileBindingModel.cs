using System;
using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels
{
    public class EditProfileBindingModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Url]
        [MinLength(2)]
        [MaxLength(500)]
        public string Website { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [EmailAddress]
        public string DisplayEmail { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        public string Telephones { get; set; }

        public AddressBindingModel Address { get; set; }
    }
}
