﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class EditOrganizationDescriptionViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
