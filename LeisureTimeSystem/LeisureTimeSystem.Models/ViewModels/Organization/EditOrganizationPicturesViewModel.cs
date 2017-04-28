using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class EditOrganizationPicturesViewModel
    {
        public int OrganizationId { get; set; }

        public IEnumerable<EditPictureViewModel> Pictures { get; set; } 
    }
}
