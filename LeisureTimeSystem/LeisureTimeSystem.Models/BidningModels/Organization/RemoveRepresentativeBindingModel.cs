using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels.Organization
{
    public class RemoveRepresentativeBindingModel
    {
        [Required]
        public int RepresentativeId { get; set; }

        [Required]
        public int OrganizationId { get; set; }

    }
}
