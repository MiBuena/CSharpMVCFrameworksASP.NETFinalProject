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

        public int Id { get; set; }

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

        public int DisciplineId { get; set; }

        public int OrganizationId { get; set; }


        public IEnumerable<DisciplineViewModel> Disciplines { get; set; } 
    }
}
