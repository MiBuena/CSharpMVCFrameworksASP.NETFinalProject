using LeisureTimeSystem.Models.Enums;
using LeisureTimeSystem.Models.ViewModels.Course;

namespace LeisureTimeSystem.Models.BidningModels
{
    public class ManageCourseApplicationBindingModel
    {
        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public ApplicationStatus Status { get; set; }
    }
}
