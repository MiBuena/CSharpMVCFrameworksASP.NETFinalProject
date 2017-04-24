using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels
{
    public class AllDisciplineOrganizationsViewModel
    {
        public string DisciplineName { get; set; }

        public IEnumerable<OrganizationViewModel> OrganizationViewModels { get; set; } 
    }
}
