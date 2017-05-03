using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels.Applications
{
    public class ApplicationBindingModel
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
