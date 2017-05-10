using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureTimeSystem.Attributes;
using LeisureTimeSystem.Models.BidningModels.Admin;
using LeisureTimeSystem.Models.Interfaces;
using LeisureTimeSystem.Services.Interfaces;
using LeisureTimeSystem.Services.Services;
using Microsoft.AspNet.Identity.Owin;

namespace LeisureTimeSystem.Areas.Admin.Controllers
{
    [LeisureTimeAuthorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private IAdminService service;
        private IApplicationUserManager _userManager;


        public AdminController(IAdminService service) : this(service, null)
        {
        }

        public AdminController(IAdminService service, IApplicationUserManager userManager)
        {
            this.service = service;
            this.UserManager = userManager;
        }

        public IApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SetRoles()
        {
            var setRolesViewModel = this.service.GetSetRolesViewModel();


            return View(setRolesViewModel);
        }

        [HttpPost]
        public ActionResult SetRoles(SetRolesBindingModel setRolesBindingModel)
        {
            if (this.ModelState.IsValid)
            {
                this.service.SetRoles(setRolesBindingModel, this.UserManager);
                return this.RedirectToAction("SetRoles");
            }

            var viewModels = this.service.GetSetRolesViewModel();

            return View(viewModels);

        }

        public ActionResult RemoveRoles(string userId, string roleName)
        {
            this.service.RemoveRole(roleName, userId, this.UserManager);

            return RedirectToAction("SetRoles");
        }


    }
}