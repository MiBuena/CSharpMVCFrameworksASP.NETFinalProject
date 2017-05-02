using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LeisureTimeSystem.Data;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Services.Services;

namespace LeisureTimeSystem.Controllers
{
    public class HomeController : Controller
    {
        private HomeService homeService;

        public HomeController()
        {
            this.homeService = new HomeService();
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
            NavbarViewModel model = this.homeService.GetNavbarViewModel();

            return this.PartialView(model);
        }

        public ActionResult Update()
        {
            return this.PartialView("_NamePartial", new string[]
            {
                "Ivan", "Nasko", "Valio"
            });
        }




        //public ActionResult RenderSubcategory()
        //{
        //}


    }
}