using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.ViewModels.Course;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class AllOrganizationCoursesViewModel
    {

        public IEnumerable<CourseViewModel> Courses { get; set; } 
    }
}
