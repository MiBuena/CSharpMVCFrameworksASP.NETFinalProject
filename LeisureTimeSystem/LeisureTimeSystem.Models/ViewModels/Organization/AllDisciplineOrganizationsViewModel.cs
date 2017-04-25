using System.Collections.Generic;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class AllDisciplineOrganizationsViewModel
    {
        public string DisciplineName { get; set; }

        public IEnumerable<OrganizationViewModel> OrganizationViewModels { get; set; } 
    }
}
