using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class DeletePictureViewModel
    {
        [Required]
        public int PictureId { get; set; }

        [Required]
        public string Path { get; set; }

        public int OrganizationId { get; set; }
    }
}
