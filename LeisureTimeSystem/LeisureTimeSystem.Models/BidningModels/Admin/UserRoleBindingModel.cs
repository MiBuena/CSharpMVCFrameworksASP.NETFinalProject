using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.BidningModels.Admin
{
    public class UserRoleBindingModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string NewRoleName { get; set; }
    }
}
