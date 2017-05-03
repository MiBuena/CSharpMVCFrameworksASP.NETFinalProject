using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.ViewModels.Course
{
    public class ApplyViewModel
    {
        [Required]
        public ApplyStudentViewModel ApplyStudentViewModel { get; set; }

        [Required]
        public ApplyCourseViewModel ApplyCourseViewModel { get; set; }

    }
}
