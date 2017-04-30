using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Admin
{
    public class SetRolesViewModel
    {
        public IList<PersonRoleViewModel> PersonRoles { get; set; }

        public IList<RoleViewModel> AllRoles { get; set; }
    }
}
