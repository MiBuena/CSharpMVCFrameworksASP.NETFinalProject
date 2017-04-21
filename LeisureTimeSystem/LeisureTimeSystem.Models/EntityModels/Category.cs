using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.EntityModels
{
    public class Category
    {
        public Category()
        {
            this.Subcategories = new HashSet<Category>();
            this.Disciplines = new HashSet<Discipline>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> Subcategories { get; set; }

        public virtual ICollection<Discipline> Disciplines { get; set; }
    }
}
