using Microsoft.Build.Framework;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class AddOrganizationDisciplineViewModel
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
