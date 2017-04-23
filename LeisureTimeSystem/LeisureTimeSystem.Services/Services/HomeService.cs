using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;

namespace LeisureTimeSystem.Services.Services
{
    public class HomeService : Service
    {
        public NavbarViewModel GetNavbarViewModel()
        {
            ICollection<Category> mainCategories = this.Context.Categories.Include(x => x.Subcategories).Where(x => x.ParentCategory == null).ToList();

            var categoryVms = Mapper.Map<ICollection<Category>, ICollection<CategoryViewModel>>(mainCategories);

            NavbarViewModel model = new NavbarViewModel()
            {
                MainCategoriesViewModels = categoryVms
            };

            return model;
        }
    }
}
