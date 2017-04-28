using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.Enums;

namespace LeisureTimeSystem.Models.ViewModels.Course
{
    public class CourseApplicationViewModel
    {
        public ApplicationCourseViewModel Course { get; set; }

        public ApplicationStudentViewModel Student { get; set; }

        public ApplicationStatus Status { get; set; }
    }
}
