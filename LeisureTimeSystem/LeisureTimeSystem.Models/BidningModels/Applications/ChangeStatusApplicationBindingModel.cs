using System.ComponentModel.DataAnnotations;
using LeisureTimeSystem.Models.Enums;

namespace LeisureTimeSystem.Models.BidningModels.Applications
{
    public class ChangeStatusApplicationBindingModel
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public ApplicationStatus Status { get; set; }

    }
}
