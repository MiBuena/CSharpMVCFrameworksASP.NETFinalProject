using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels.Course
{
    public class AddNewCourseBindingModel
    {
        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public int DisciplineId { get; set; }

        [Required]
        public NewCourseBindingModel Course { get; set; }

    }
}
