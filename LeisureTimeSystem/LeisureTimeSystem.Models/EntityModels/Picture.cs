using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace LeisureTimeSystem.Models.EntityModels
{
    public class Picture
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Path { get; set; }

    }
}
