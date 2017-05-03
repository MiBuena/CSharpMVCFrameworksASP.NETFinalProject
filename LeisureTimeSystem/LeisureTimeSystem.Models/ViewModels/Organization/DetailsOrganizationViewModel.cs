using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels.Course;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class DetailsOrganizationViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Url]
        [MinLength(2)]
        [MaxLength(500)]
        public string Website { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [EmailAddress]
        public string DisplayEmail { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        public string Telephones { get; set; }

        public string AddressId { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        [MaxLength(3000)]
        public string Description { get; set; }

        public string ProfilePicturePath { get; set; }

        public bool IsAuthorizedToModify { get; set; }

        public virtual ICollection<string> DisciplineNames { get; set; }

        public virtual ICollection<string> Pictures { get; set; }

    }
}
