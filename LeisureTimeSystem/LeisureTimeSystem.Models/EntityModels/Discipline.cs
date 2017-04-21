using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.EntityModels.AbstractClasses;
using Microsoft.Build.Framework;

namespace LeisureTimeSystem.Models.EntityModels
{
    public class Discipline : NameableObject
    {
        public int Id { get; set; }

        [Required]
        public virtual Category Category { get; set; }
    }
}
