using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using AutoMapper;
using LeisureTimeSystem.Data.Interfaces;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Models.ViewModels.Article;
using LeisureTimeSystem.Models.ViewModels.Category;
using LeisureTimeSystem.Models.ViewModels.Course;
using LeisureTimeSystem.Models.ViewModels.Home;
using LeisureTimeSystem.Models.ViewModels.Tag;
using LeisureTimeSystem.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace LeisureTimeSystem.Services.Services
{
    public class HomeService : Service, IHomeService
    {
        public HomeService(ILeisureTimeSystemDbContext context) : base(context)
        {
        }

        public HomePageViewModel GetHomePageViewModel()
        {
            var tags = this.Context.Tags.OrderByDescending(tag=>tag.Articles.Count).Take(5);

            var tagsViewModels = Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(tags);

            var futureCourses = this.Context.Courses.OrderBy(x => x.SubscriptionDeadLine).Take(5);

            var coursesViewModels = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseHomeViewModel>>(futureCourses);

            var articles = this.Context.Articles.OrderByDescending(x => x.Date).Take(5);

            var homePageArticles = Mapper.Map<IEnumerable<Article>, IEnumerable<HomePageArticle>>(articles);


            HomePageViewModel model = new HomePageViewModel()
            {
                Courses = coursesViewModels,
                Tags = tagsViewModels,
                Articles = homePageArticles
            };

            return model;
        }

        public NavbarViewModel GetNavbarViewModel(string currentUserId, IPrincipal user)
        {
            ICollection<Category> mainCategories = this.Context.Categories.Include(x => x.Subcategories).Where(x => x.ParentCategory == null).ToList();

            var categoryVms = Mapper.Map<ICollection<Category>, ICollection<CategoryViewModel>>(mainCategories);

            var isAdministrator = false;

            if (currentUserId != null)
            {
                isAdministrator = user.IsInRole("Administrator");
            }

            NavbarViewModel model = new NavbarViewModel
            {
                MainCategoriesViewModels = categoryVms,
                IsAdmin = isAdministrator
            };

            return model;
        }


    }
}
