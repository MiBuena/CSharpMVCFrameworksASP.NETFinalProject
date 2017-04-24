using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureTimeSystem.Services.Services;
using Microsoft.AspNet.Identity;

namespace LeisureTimeSystem.Controllers
{
    public class ProfileController : Controller
    {
        private ProfileService service;

        public ProfileController()
        {
            this.service = new ProfileService();
        }

        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();

            var viewModel = this.service.GetProfileDetailsProfileViewModel(currentUserId);

            return View(viewModel);
        }

    }
}