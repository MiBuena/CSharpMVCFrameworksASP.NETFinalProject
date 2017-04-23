using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.Attributes;
using LeisureTimeSystem.Models.EntityModels;

namespace LeisureTimeSystem.Models.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime SubscriptionDeadLine { get; set; }

        public int MaximumNumberOfParticipants { get; set; }

        public bool CanStudentsSignUp { get; set; }

        public string DisciplineName { get; set; }
    }
}
