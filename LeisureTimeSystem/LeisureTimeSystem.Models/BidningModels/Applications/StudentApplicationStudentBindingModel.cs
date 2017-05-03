using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels.Applications
{
    public class StudentApplicationStudentBindingModel
    {
        [Required]
        public int StudentId { get; set; }
    }
}
