using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.EntityModels
{
    public class Organization
    {
        public Organization()
        {
            this.Courses = new HashSet<Course>();
            this.Representatives = new HashSet<Student>();
            this.Pictures = new HashSet<string>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Student> Representatives { get; set; }

        public virtual ICollection<string> Pictures { get; set; }
    }
}
