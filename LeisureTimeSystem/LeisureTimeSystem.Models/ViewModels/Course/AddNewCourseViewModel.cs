using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Course
{
    public class AddNewCourseViewModel
    {
        [Required]
        public int OrganizationId { get; set; }

        [Display(Name="Organization name")]
        public string OrganizationName { get; set; }

        public IEnumerable<DisciplineViewModel> Disciplines { get; set; } 

        [Required]
        public NewCourseViewModel Course { get; set; }
    }
}
