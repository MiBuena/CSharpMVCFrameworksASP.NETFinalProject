using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class DeletePictureViewModel
    {
        public int PictureId { get; set; }

        public string Path { get; set; }

        public int OrganizationId { get; set; }
    }
}
