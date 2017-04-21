using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.EntityModels
{
    public class Student
    {
        public Student()
        {
            this.AllCourseApplicationsSubmittedByThisUser = new HashSet<CourseApplicationData>();
            this.AllCourseApplicationsAsAStudent = new HashSet<CourseApplicationData>();
            this.OrganizationsTheyRepresent = new HashSet<Organization>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        //This collection contains all courses the user made an application for themselves or for another person
        [InverseProperty("ApplicationMaker")]
        public virtual ICollection<CourseApplicationData> AllCourseApplicationsSubmittedByThisUser { get; set; }

        //This collection contains all courses the user has applied to
        [InverseProperty("Student")]
        public virtual ICollection<CourseApplicationData> AllCourseApplicationsAsAStudent { get; set; }

        public virtual ICollection<Organization> OrganizationsTheyRepresent { get; set; }
    }
}
