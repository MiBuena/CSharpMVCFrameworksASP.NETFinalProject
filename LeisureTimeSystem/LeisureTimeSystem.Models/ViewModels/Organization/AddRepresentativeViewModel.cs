using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.ViewModels.Student;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class AddRepresentativeViewModel
    {
        [Required]
        public int OrganizationId { get; set; }

        [Display(Name = "All students")]
        public IEnumerable<RepresentativesStudentViewModel> AllStudents { get; set; }

    }
}
