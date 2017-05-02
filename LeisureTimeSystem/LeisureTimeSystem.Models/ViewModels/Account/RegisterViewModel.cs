using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        [Display(Name = "Username")]
        public string Username { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
