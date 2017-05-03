using System;
using System.ComponentModel.DataAnnotations;
using LeisureTimeSystem.Models.Attributes;

namespace LeisureTimeSystem.Models.BidningModels.Course
{
    public class NewCourseBindingModel
    {
        [Required]
        public string Name { get; set; }

        [MinLength(2)]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        [StartDate]
        public DateTime StartDate { get; set; }

        [Required]
        [EndDate]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime SubscriptionDeadLine { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int MaximumNumberOfParticipants { get; set; }
    }
}
