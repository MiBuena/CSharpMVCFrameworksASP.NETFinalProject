using System.ComponentModel.DataAnnotations;
using LeisureTimeSystem.Models.BidningModels.Address;

namespace LeisureTimeSystem.Models.BidningModels.Organization
{
    public class EditOrganizationDataBindingModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Url]
        [MinLength(2)]
        [MaxLength(500)]
        public string Website { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [EmailAddress]
        [Display(Name = "Display email")]
        public string DisplayEmail { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        public string Telephones { get; set; }

        [MaxLength(3000)]
        public string Description { get; set; }

        public AddressBindingModel Address { get; set; }
    }
}
