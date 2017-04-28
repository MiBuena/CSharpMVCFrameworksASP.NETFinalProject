using LeisureTimeSystem.Models.Enums;

namespace LeisureTimeSystem.Models.BidningModels
{
    public class ChangeStatusApplicationBindingModel
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public ApplicationStatus Status { get; set; }
    }
}
