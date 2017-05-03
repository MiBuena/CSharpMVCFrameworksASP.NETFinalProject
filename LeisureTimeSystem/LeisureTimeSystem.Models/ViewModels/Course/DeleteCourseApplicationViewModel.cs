using System;
using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.ViewModels.Course
{
    public class DeleteCourseApplicationViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        public string OrganizationName { get; set; }

        [Required]
        public int StudentId { get; set; }
    }
}
