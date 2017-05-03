﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Organization
{
    public class EditPictureViewModel
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Path { get; set; }
    }
}
