using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.BidningModels.Course
{
    public class CourseApplicationCourseBindingModel
    {
        [Required]
        public int CourseId { get; set; }
    }
}
