using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class UploadOrganizationPictureViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}
