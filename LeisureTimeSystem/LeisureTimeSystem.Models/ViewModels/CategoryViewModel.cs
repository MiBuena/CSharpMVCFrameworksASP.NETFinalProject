using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            this.SubCategoryViewModels = new HashSet<CategoryViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryViewModel> SubCategoryViewModels { get; set; }
    }
}
