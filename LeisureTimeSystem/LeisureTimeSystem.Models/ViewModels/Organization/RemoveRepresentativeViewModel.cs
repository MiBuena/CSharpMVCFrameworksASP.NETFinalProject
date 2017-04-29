using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.ViewModels.Student;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class RemoveRepresentativeViewModel
    {
        public int RepresentativeId { get; set; }

        public string RepresentativeName { get; set; }

        public int OrganizationId { get; set; }
    }
}
