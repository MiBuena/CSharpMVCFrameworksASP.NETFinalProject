using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.EntityModels.AbstractClasses;
using Microsoft.Build.Framework;

namespace LeisureTimeSystem.Models.EntityModels
{
    [Table("Students")]
    public class Student : ContactableObject
    {
        public Student()
        {
            this.AllCourseApplicationsAsAStudent = new HashSet<CourseApplicationData>();
            this.OrganizationsTheyRepresent = new HashSet<Organization>();
        }

        public int Id { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }

        public string ProfilePicturePath { get; set; }

        public virtual ApplicationUser User { get; set; }

        //This collection contains all courses the user has applied to
        [InverseProperty("Student")]
        public virtual ICollection<CourseApplicationData> AllCourseApplicationsAsAStudent { get; set; }

        public virtual ICollection<Organization> OrganizationsTheyRepresent { get; set; }
    }
}
