using System.Collections.Generic;

namespace LeisureTimeSystem.Models.ViewModels.Category
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
