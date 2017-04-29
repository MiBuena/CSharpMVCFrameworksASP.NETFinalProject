using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LeisureTimeSystem.Models.Attributes;
using LeisureTimeSystem.Models.ViewModels;

namespace LeisureTimeSystem.Models.BidningModels
{
    public class EditCourseBindingModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        [MinLength(2)]
        [MaxLength(70)]
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

        public int DisciplineId { get; set; }

        public int OrganizationId { get; set; }

    }
}
