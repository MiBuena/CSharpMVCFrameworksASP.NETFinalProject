using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.EntityModels
{
    public class CourseApplicationData
    {
        [ForeignKey("Course")]
        [Key, Column(Order = 0)]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        [ForeignKey("Student")]
        [Key, Column(Order = 1)]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }


        public bool IsApplicationApproved { get; set; }
    }
}
