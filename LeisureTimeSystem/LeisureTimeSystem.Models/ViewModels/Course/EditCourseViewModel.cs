using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.Attributes;

namespace LeisureTimeSystem.Models.ViewModels.Course
{
    public class EditCourseViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MinLength(2)]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        [StartDate]
        [DataType(DataType.Date)]
        [Display(Name="Start date")]
        public DateTime StartDate { get; set; }

        [Required]
        [EndDate]
        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Subscription deadline")]
        public DateTime SubscriptionDeadLine { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int MaximumNumberOfParticipants { get; set; }

        public int DisciplineId { get; set; }

        public int OrganizationId { get; set; }


        public IEnumerable<DisciplineViewModel> Disciplines { get; set; } 
    }
}
