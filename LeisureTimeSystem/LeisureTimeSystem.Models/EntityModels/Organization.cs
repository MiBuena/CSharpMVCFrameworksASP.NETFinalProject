﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.EntityModels.AbstractClasses;
using LeisureTimeSystem.Models.EntityModels.Interfaces;

namespace LeisureTimeSystem.Models.EntityModels
{
    [Table("Organizations")]
    public class Organization : ContactableObject
    {
        public Organization()
        {
            this.Courses = new HashSet<Course>();
            this.Representatives = new HashSet<Student>();
            this.Pictures = new HashSet<Picture>();
            this.Disciplines = new HashSet<Discipline>();
        }

        public int Id { get; set; }

        [MaxLength(3000)]
        public string Description { get; set; }

        public virtual Picture ProfilePicture { get; set; }

        public virtual ICollection<Discipline> Disciplines { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Student> Representatives { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
