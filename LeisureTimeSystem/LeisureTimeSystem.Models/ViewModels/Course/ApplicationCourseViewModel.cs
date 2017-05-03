using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Course
{
    public class ApplicationCourseViewModel
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        [Display(Name="Course name")]
        public string Name { get; set; }
    }
}
