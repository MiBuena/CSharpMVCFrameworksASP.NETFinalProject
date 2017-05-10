using System.Web.Mvc;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace LeisureTimeSystem.Controllers
{
    public class HomeController : Controller
    {
        private IHomeService homeService;

        public HomeController(IHomeService service)
        {
            this.homeService = service;
        }

        public ActionResult Index()
        {

            var homePageViewModel = this.homeService.GetHomePageViewModel();

            return View(homePageViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RenderNavbar()
        {
            string currentUserId = User.Identity.GetUserId();

            NavbarViewModel model = this.homeService.GetNavbarViewModel(currentUserId, this.User);

            return this.PartialView(model);
        }
    }
}