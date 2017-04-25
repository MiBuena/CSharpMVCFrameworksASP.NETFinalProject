using System;
using System.ComponentModel.DataAnnotations;
using LeisureTimeSystem.Models.Enums;

namespace LeisureTimeSystem.Models.ViewModels.Course
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Subscription deadline")]
        public DateTime SubscriptionDeadLine { get; set; }

        [Display(Name = "Open for sign up")]
        public bool CanStudentsSignUp { get; set; }

        public string DisciplineName { get; set; }

        [Display(Name = "Organization name")]
        public string OrganizationName { get; set; }

        public ApplicationStatus Status { get; set; }
    }
}
