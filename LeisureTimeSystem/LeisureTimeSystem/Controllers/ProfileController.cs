using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureTimeSystem.Attributes;
using LeisureTimeSystem.Exceptions;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.BidningModels.Profile;
using LeisureTimeSystem.Services.Interfaces;
using LeisureTimeSystem.Services.Services;
using Microsoft.AspNet.Identity;
using Constants = LeisureTimeSystem.Models.Utils.Constants;

namespace LeisureTimeSystem.Controllers
{
    [HandleError(ExceptionType = typeof(NotAuthorizedException), View = "Error")]
    public class ProfileController : Controller
    {
        private IProfileService service;

        public ProfileController(IProfileService service)
        {
            this.service = service;
        }

        [LeisureTimeAuthorize]
        public ActionResult Details()
        {
            string currentUserId = User.Identity.GetUserId();

            var viewModel = this.service.GetProfileDetailsProfileViewModel(currentUserId);

            return View(viewModel);
        }

        [LeisureTimeAuthorize]
        public ActionResult Edit(int studentId)
        {
            CheckIfUserIsAllowedToPerformThisAction(studentId, Constants.EditUserProfileExceptionMessage);

            var editStudentProfile = this.service.GetEditProfileViewModel(studentId);

            return View(editStudentProfile);

        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult Edit(EditProfileBindingModel model)
        {
            CheckIfUserIsAllowedToPerformThisAction(model.Id, Constants.EditUserProfileExceptionMessage);

            if (this.ModelState.IsValid)
            {
                this.service.EditProfile(model);
                return this.RedirectToAction("Details");
            }

            return this.View(this.service.GetEditProfileViewModel(model.Id));
        }

        [LeisureTimeAuthorize]
        public ActionResult RenderStudentOrganizations(int studentId)
        {
            CheckIfUserIsAllowedToPerformThisAction(studentId, Constants.ViewUserOrganizationsExceptionMessage);

            var organizationsViewModels = this.service.GetOrganizations(studentId);

            return this.PartialView(organizationsViewModels);
        }

        [LeisureTimeAuthorize]
        public ActionResult RenderStudentCourses(int studentId)
        {
            CheckIfUserIsAllowedToPerformThisAction(studentId, Constants.ViewUserCoursesExceptionMessage);

            var coursesViewModels = this.service.GetCourseViewModelsByStudent(studentId);
            
            return this.PartialView(coursesViewModels);
        }

        private void CheckIfUserIsAllowedToPerformThisAction(int studentId, string message)
        {
            string currentUserId = User.Identity.GetUserId();

            bool isOwnProfile = this.service.IsOwnProfile(studentId, currentUserId);

            if (!isOwnProfile)
            {
                throw new NotAuthorizedException(message);
            }
        }

    }
}