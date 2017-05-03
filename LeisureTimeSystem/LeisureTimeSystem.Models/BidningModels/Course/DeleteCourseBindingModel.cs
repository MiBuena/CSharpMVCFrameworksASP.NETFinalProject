using Microsoft.Build.Framework;

namespace LeisureTimeSystem.Models.BidningModels.Course
{
    public class DeleteCourseBindingModel
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        public int OrganizationId { get; set; }
    }
}
