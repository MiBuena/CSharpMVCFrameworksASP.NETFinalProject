using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.EntityModels
{
    public class Discipline
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Category Category { get; set; }
    }
}
