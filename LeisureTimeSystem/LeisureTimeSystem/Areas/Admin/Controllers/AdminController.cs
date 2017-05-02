using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureTimeSystem.Attributes;
using LeisureTimeSystem.Models.BidningModels.Admin;
using LeisureTimeSystem.Services.Services;

namespace LeisureTimeSystem.Areas.Admin.Controllers
{
    [LeisureTimeAuthorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private AdminService service;

        public AdminController()
        {
            this.service = new AdminService();
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
                this.service.SetRoles(setRolesBindingModel);
                return this.RedirectToAction("SetRoles");
            }

            var viewModels = this.service.GetSetRolesViewModel();

            return View(viewModels);

        }

        public ActionResult RemoveRoles(string userId, string roleName)
        {
            this.service.RemoveRole(roleName, userId);

            return RedirectToAction("SetRoles");
        }
    }
}