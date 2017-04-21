using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.EntityModels.AbstractClasses;

namespace LeisureTimeSystem.Models.EntityModels
{
    [Table("Organizations")]
    public class Organization : ContactableObject
    {
        public Organization()
        {
            this.Courses = new HashSet<Course>();
            this.Representatives = new HashSet<Student>();
            this.Pictures = new HashSet<string>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Student> Representatives { get; set; }

        public virtual ICollection<string> Pictures { get; set; }
    }
}
