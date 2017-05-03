using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Admin
{
    public class PersonRoleViewModel
    {
        public string Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        public string NewRoleName { get; set; }

        [Display(Name = "Add role")]
        public List<RoleViewModel> CurrentRoleViewModels { get; set; }
    }
}
