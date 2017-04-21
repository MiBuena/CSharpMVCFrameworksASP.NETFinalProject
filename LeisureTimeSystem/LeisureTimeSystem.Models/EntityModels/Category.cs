using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.EntityModels.AbstractClasses;

namespace LeisureTimeSystem.Models.EntityModels
{
    [Table("Categories")]
    public class Category : NameableObject
    {
        public Category()
        {
            this.Subcategories = new HashSet<Category>();
            this.Disciplines = new HashSet<Discipline>();
        }

        public int Id { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> Subcategories { get; set; }

        public virtual ICollection<Discipline> Disciplines { get; set; }
    }
}
