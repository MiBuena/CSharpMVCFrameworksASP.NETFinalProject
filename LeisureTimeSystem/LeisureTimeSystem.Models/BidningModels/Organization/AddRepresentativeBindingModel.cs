using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels.Organization
{
    public class AddRepresentativeBindingModel
    {
        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public int StudentId { get; set; }

    }
}
