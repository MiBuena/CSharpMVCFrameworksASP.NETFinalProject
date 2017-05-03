using System;
using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.ViewModels.Course
{
    public class ApplyCourseViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name= "Course name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Organization name")]
        public string OrganizationName { get; set; }
    }
}
