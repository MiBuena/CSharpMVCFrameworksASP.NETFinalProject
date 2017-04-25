using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureTimeSystem.Models.BidningModels;
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

        public ActionResult Details()
        {
            string currentUserId = User.Identity.GetUserId();

            var viewModel = this.service.GetProfileDetailsProfileViewModel(currentUserId);

            return View(viewModel);
        }

        public ActionResult Edit(int studentId)
        {
            var editStudentProfile = this.service.GetEditProfileViewModel(studentId);

            return View(editStudentProfile);

        }

        [HttpPost]
        public ActionResult Edit(EditProfileBindingModel editUserProfileBindingModel)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditProfile(editUserProfileBindingModel);
                return this.RedirectToAction("Details");
            }

            return this.View(this.service.GetEditProfileViewModel(editUserProfileBindingModel.Id));
        }



    }
}