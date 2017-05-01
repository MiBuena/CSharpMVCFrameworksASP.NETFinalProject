using LeisureTimeSystem.Models.Enums;
using LeisureTimeSystem.Models.ViewModels.Course;

namespace LeisureTimeSystem.Models.BidningModels.Course
{
    public class CourseApplicationBindingModel
    {
        public CourseApplicationCourseBindingModel Course { get; set; }

        public StudentApplicationStudentBindingModel Student { get; set; }

        public ApplicationStatus Status { get; set; }
    }
}
