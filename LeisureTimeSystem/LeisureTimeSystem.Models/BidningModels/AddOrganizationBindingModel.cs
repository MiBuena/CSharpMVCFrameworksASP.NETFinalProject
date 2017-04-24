using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels
{
    public class AddOrganizationBindingModel
    {
        public AddOrganizationBindingModel()
        {
            this.Address = new AddressBindingModel();
        }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(3000)]
        public string Description { get; set; }

        [Url]
        [MinLength(2)]
        [MaxLength(500)]
        public string Website { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        public string Telephones { get; set; }

        public string RepresentativeId { get; set; }

        public int DisciplineId { get; set; }

        public AddressBindingModel Address { get; set; }
    }
}
