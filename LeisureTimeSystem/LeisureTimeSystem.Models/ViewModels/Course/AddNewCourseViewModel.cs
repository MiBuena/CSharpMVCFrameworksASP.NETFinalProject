using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Course
{
    public class AddNewCourseViewModel
    {
        public int OrganizationId { get; set; }

        public string OrganizationName { get; set; }

        public IEnumerable<DisciplineViewModel> Disciplines { get; set; } 

        public NewCourseViewModel Course { get; set; }
    }
}
