using LeisureTimeSystem.Models.Enums;
using Microsoft.Build.Framework;

namespace LeisureTimeSystem.Models.BidningModels.Applications
{
    public class ManageCourseApplicationBindingModel
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public ApplicationStatus Status { get; set; }
    }
}
