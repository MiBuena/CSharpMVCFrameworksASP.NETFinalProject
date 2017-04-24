using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.EntityModels.AbstractClasses;
using Microsoft.Build.Framework;

namespace LeisureTimeSystem.Models.EntityModels
{
    public class Discipline : NameableObject
    {
        public Discipline()
        {
            this.Courses = new HashSet<Course>();
            this.Organizations = new HashSet<Organization>();
        }

        public int Id { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        public virtual ICollection<Organization> Organizations { get; set; }

        public virtual ICollection<Course> Courses { get; set; } 
    }
}
