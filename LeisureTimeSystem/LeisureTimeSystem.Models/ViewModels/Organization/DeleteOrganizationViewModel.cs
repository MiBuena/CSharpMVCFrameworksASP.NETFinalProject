using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class DeleteOrganizationViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } 
    }
}
