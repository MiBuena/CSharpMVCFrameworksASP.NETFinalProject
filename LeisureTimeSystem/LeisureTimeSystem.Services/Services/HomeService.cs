using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Models.ViewModels.Category;
using LeisureTimeSystem.Models.ViewModels.Course;
using LeisureTimeSystem.Models.ViewModels.Home;
using LeisureTimeSystem.Models.ViewModels.Tag;

namespace LeisureTimeSystem.Services.Services
{
    public class HomeService : Service
    {

        public HomePageViewModel GetHomePageViewModel()
        {
            var tags = this.Context.Tags.OrderByDescending(tag=>tag.Articles.Count).Take(5);

            var tagsViewModels = Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(tags);

            var futureCourses = this.Context.Courses.OrderBy(x => x.SubscriptionDeadLine).Take(5);

            var coursesViewModels = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseHomeViewModel>>(futureCourses);

            HomePageViewModel model = new HomePageViewModel()
            {
                Courses = coursesViewModels,
                Tags = tagsViewModels
            };

            return model;
        }

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
