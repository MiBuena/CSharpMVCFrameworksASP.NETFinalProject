using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.ViewModels.Article;
using LeisureTimeSystem.Models.ViewModels.Course;
using LeisureTimeSystem.Models.ViewModels.Tag;

namespace LeisureTimeSystem.Models.ViewModels.Home
{
    public class HomePageViewModel
    {
        public IEnumerable<CourseHomeViewModel> Courses { get; set; }
         
        public IEnumerable<TagViewModel> Tags { get; set; }

        public IEnumerable<HomePageArticle> Articles { get; set; } 
    }
}
