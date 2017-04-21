using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.EntityModels.AbstractClasses;

namespace LeisureTimeSystem.Models.EntityModels
{
    public class Discipline : NameableObject
    {
        public int Id { get; set; }

        public virtual Category Category { get; set; }
    }
}
