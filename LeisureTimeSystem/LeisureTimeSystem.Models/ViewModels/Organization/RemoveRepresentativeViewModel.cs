using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.ViewModels.Student;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class RemoveRepresentativeViewModel
    {
        [Required]
        public int RepresentativeId { get; set; }

        public string RepresentativeName { get; set; }

        [Required]
        public int OrganizationId { get; set; }
    }
}
