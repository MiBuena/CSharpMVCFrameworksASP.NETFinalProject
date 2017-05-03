using Microsoft.Build.Framework;

namespace LeisureTimeSystem.Models.BidningModels.Organization
{
    public class DeletePictureBindingModel
    {
        [Required]
        public int PictureId { get; set; }

        [Required]
        public int OrganizationId { get; set; }
    }
}
