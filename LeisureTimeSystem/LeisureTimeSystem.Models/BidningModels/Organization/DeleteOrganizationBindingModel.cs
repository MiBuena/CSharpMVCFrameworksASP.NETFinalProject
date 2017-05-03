using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels.Organization
{
    public class DeleteOrganizationBindingModel
    {
        [Required]
        public int Id { get; set; }

    }
}
