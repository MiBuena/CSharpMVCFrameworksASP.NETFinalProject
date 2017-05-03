using LeisureTimeSystem.Models.BidningModels.Applications;
using LeisureTimeSystem.Models.Enums;
using LeisureTimeSystem.Models.ViewModels.Course;
using Microsoft.Build.Framework;

namespace LeisureTimeSystem.Models.BidningModels.Course
{
    public class CourseApplicationBindingModel
    {
        [Required]
        public CourseApplicationCourseBindingModel Course { get; set; }

        [Required]
        public StudentApplicationStudentBindingModel Student { get; set; }

        public ApplicationStatus Status { get; set; }
    }
}
