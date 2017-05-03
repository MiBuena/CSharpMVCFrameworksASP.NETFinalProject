using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace LeisureTimeSystem.Models.ViewModels.Category
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            this.SubCategoryViewModels = new HashSet<CategoryViewModel>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<CategoryViewModel> SubCategoryViewModels { get; set; }
    }
}
