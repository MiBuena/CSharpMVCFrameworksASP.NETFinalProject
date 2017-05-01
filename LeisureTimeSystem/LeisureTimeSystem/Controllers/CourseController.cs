using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LeisureTimeSystem.Attributes;
using LeisureTimeSystem.Exceptions;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.BidningModels.Course;
using LeisureTimeSystem.Models.ViewModels.Course;
using LeisureTimeSystem.Services.Services;
using Microsoft.AspNet.Identity;
using Constants = LeisureTimeSystem.Models.Utils.Constants;

namespace LeisureTimeSystem.Controllers
{
    [HandleError(ExceptionType = typeof(NotAuthorizedException), View = "Error")]
    public class CourseController : Controller
    {
        private CourseService service;

        public CourseController()
        {
            this.service = new CourseService();
        }

        [LeisureTimeAuthorize]
        public ActionResult Add(int organizationId)
        {
            CheckIfUserIsAllowedToAddACourse(organizationId, Constants.AddCoursesExceptionMessage);

            var addNewCourseViewModel = this.service.GetAddNewCourseViewModel(organizationId);

            return View(addNewCourseViewModel);
        }

        private void CheckIfUserIsAllowedToAddACourse(int organizationId, string exceptionMessage)
        {
            string currentUserId = User.Identity.GetUserId();

            bool isAllowedToAddAcourse = this.service.IsAllowedToAddAcourse(currentUserId, organizationId);

            if (!isAllowedToAddAcourse)
            {
                throw new NotAuthorizedException(exceptionMessage);
            }
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult Add(AddNewCourseBindingModel model)
        {
            CheckIfUserIsAllowedToAddACourse(model.OrganizationId, Constants.AddCoursesExceptionMessage);

            if (this.ModelState.IsValid)
            {
                this.service.AddNewCourse(model);
                return this.RedirectToAction("ManageOrganizationCourses", "Organization",
                    new {organizationId = model.OrganizationId});
             }

            var courseViewModel = Mapper.Map<NewCourseBindingModel, NewCourseViewModel>(model.Course);

            var addNewCourseViewModel = this.service.GetAddNewCourseViewModel(model.OrganizationId);

            addNewCourseViewModel.Course = courseViewModel;

            return View(addNewCourseViewModel);
        }

        [LeisureTimeAuthorize]
        public ActionResult Edit(int courseId)
        {
            CheckIfIsAllowedToModifyCourse(courseId, Constants.ModifyCourseExceptionMessage);
            
            var editViewModel = this.service.GetEditCourseViewModel(courseId);

            return this.View(editViewModel);
        }
        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult Edit(EditCourseBindingModel model)
        {
            CheckIfIsAllowedToModifyCourse(model.Id, Constants.ModifyCourseExceptionMessage);

            if (this.ModelState.IsValid)
            {
                this.service.EditCourse(model);
                return this.RedirectToAction("ManageOrganizationCourses", "Organization", new {organizationId = model.OrganizationId});
            }

            var editViewModel = this.service.GetEditCourseViewModel(model.Id);

            return this.View(editViewModel);
        }

        [LeisureTimeAuthorize]
        public ActionResult Delete(int courseId)
        {
            CheckIfIsAllowedToModifyCourse(courseId, Constants.ModifyCourseExceptionMessage);

            var deleteCourseViewModel = this.service.GetDeleteCourseViewModel(courseId);

            return View(deleteCourseViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult Delete(DeleteCourseBindingModel model)
        {
            CheckIfIsAllowedToModifyCourse(model.CourseId, Constants.ModifyCourseExceptionMessage);

            if (this.ModelState.IsValid)
            {
                this.service.DeleteCourse(model);

                return this.RedirectToAction("ManageOrganizationCourses", "Organization",
                    new {organizationId = model.OrganizationId});
            }

            var deleteCourseViewModel = this.service.GetDeleteCourseViewModel(model.CourseId);

            return View(deleteCourseViewModel);
        }


        [LeisureTimeAuthorize]
        public ActionResult ManageCourseApplications(int courseId)
        {
            CheckIfIsAllowedToModifyCourse(courseId, Constants.ModifyCourseApplicationsExceptionMessage);

            var allCourseApplicationVms = this.service.GetManageCourseApplicationsViewModel(courseId);

            return View(allCourseApplicationVms);
        }



        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult ManageCourseApplications(ManageApplicationsWrapBindingModel model)
        {
            CheckIfIsAllowedToModifyCourse(model.Applications[0].Course.CourseId, Constants.ModifyCourseApplicationsExceptionMessage);

            if (this.ModelState.IsValid)
            {
                this.service.ChangeStatus(model);
                return RedirectToAction("ManageCourseApplications", new { courseId = model.Applications.FirstOrDefault().Course.CourseId });
            }

            var allCourseApplicationVms = this.service.GetManageCourseApplicationsViewModel(model.Applications.FirstOrDefault().Course.CourseId);

            return View(allCourseApplicationVms);
        }


        public ActionResult DisciplineCourses(int disciplineId)
        {
            var courses = this.service.GetCourseViewModelsByDiscipline(disciplineId);

            return View(courses);
        }

        [LeisureTimeAuthorize]
        public ActionResult Apply(int courseId)
        {
            string currentUserId = User.Identity.GetUserId();

            var applyViewModel = this.service.GetApplyViewModel(courseId, currentUserId);

            return View(applyViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult Apply([Bind(Include = "StudentId,CourseId")] ApplicationBindingModel applicationBindingModel)
        {
            if (this.ModelState.IsValid)
            {
                this.service.SubmitApplication(applicationBindingModel);
                return this.RedirectToAction("Index", "Home", new { area = "" });
            }

            string currentUserId = User.Identity.GetUserId();

            var applyViewModel = this.service.GetApplyViewModel(applicationBindingModel.CourseId, currentUserId);

            return this.View(applyViewModel);
        }

        [LeisureTimeAuthorize]
        public ActionResult DeleteCourseApplication(int courseId)
        {
            CheckIfIsAllowedToModifyCourse(courseId, Constants.ModifyCourseApplicationsExceptionMessage);

            string currentUserId = User.Identity.GetUserId();

            var applicationToDelete = this.service.GetDeleteCourseApplicationViewModel(courseId, currentUserId);

            return View(applicationToDelete);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult DeleteCourseApplication(DeleteCourseApplicationBindingModel model)
        {
            CheckIfIsAllowedToModifyCourse(model.CourseId, Constants.ModifyCourseApplicationsExceptionMessage);

            if (this.ModelState.IsValid)
            {
                this.service.DeleteCourseApplication(model);

                return this.RedirectToAction("Details", "Profile");
            }

            string currentUserId = User.Identity.GetUserId();

            var applicationToDelete = this.service.GetDeleteCourseApplicationViewModel(model.CourseId, currentUserId);

            return View(applicationToDelete);
        }

        private void CheckIfIsAllowedToModifyCourse(int courseId, string message)
        {
            string currentUserId = User.Identity.GetUserId();

            bool isAllowedToModifyCourse = this.service.IsAllowedToModifyCourse(courseId, currentUserId);

            if (!isAllowedToModifyCourse)
            {
                throw new NotAuthorizedException(message);
            }
        }
    }
}