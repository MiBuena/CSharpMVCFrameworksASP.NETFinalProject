using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.EntityModels
{
    public class Course
    {
        public Course()
        {
            this.CoursesSubscriptionData = new HashSet<CourseApplicationData>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public DateTime SubscriptionDeadLine { get; set; }

        public int MaximumNumberOfParticipants { get; set; }

        public bool CanStudentsSignUp { get; set; }

        public virtual ICollection<CourseApplicationData> CoursesSubscriptionData { get; set; }

    }
}
