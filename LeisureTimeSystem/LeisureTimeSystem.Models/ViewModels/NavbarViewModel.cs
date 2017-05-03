using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.ViewModels.Category;

namespace LeisureTimeSystem.Models.ViewModels
{
    public class NavbarViewModel
    {
        public NavbarViewModel()
        {
            this.MainCategoriesViewModels = new HashSet<CategoryViewModel>();
        }

        public ICollection<CategoryViewModel> MainCategoriesViewModels { get; set; }

        public bool IsAdmin { get; set; }
    }
}
