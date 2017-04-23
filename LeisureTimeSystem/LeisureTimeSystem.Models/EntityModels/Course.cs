using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.Attributes;
using LeisureTimeSystem.Models.EntityModels.AbstractClasses;

namespace LeisureTimeSystem.Models.EntityModels
{
    [Table("Courses")]
    public class Course : NameableObject
    {
        private DateTime subscriptionDeadLine;

        public Course()
        {
            this.CoursesSubscriptionData = new HashSet<CourseApplicationData>();
        }

        public int Id { get; set; }

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
        public DateTime SubscriptionDeadLine
        {
            get { return this.subscriptionDeadLine; }
            set
            {
                if (value >= this.EndDate)
                {
                    throw new ArgumentException("Subscription Deadline can not be later than the course's finish date");
                }

                this.subscriptionDeadLine = value;
            }
        }

        [Required]
        [Range(0, int.MaxValue)]
        public int MaximumNumberOfParticipants { get; set; }

        public bool CanStudentsSignUp
        {
            get { return DateTime.Now <= this.SubscriptionDeadLine; }
        }

        public virtual Discipline Discipline { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual ICollection<CourseApplicationData> CoursesSubscriptionData { get; set; }

    }
}
