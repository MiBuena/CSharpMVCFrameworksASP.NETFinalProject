using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class OrganizationViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        public string Telephones { get; set; }

        public string ProfilePicturePath { get; set; }

        public string Address { get; set; }

    }
}
