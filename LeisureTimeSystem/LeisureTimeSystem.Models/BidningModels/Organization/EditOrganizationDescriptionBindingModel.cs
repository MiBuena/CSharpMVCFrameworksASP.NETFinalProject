using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels.Organization
{
    public class EditOrganizationDescriptionBindingModel
    {
        [Required]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
