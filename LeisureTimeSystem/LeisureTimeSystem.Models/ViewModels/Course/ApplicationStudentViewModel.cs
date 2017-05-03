using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Course
{
    public class ApplicationStudentViewModel
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Name="Student name")]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
