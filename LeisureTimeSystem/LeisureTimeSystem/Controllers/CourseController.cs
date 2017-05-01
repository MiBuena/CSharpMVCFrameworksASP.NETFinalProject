using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LeisureTimeSystem.Attributes;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.BidningModels.Course;
using LeisureTimeSystem.Models.ViewModels.Course;
using LeisureTimeSystem.Services.Services;
using Microsoft.AspNet.Identity;

namespace LeisureTimeSystem.Controllers
{
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
            string currentUserId = User.Identity.GetUserId();

            bool isAllowedToAddAcourse = this.service.IsAllowedToAddAcourse(currentUserId, organizationId);

            if (!isAllowedToAddAcourse)
            {
                throw new ArgumentException();
            }

            var addNewCourseViewModel = this.service.GetAddNewCourseViewModel(organizationId);

            return View(addNewCourseViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult Add(AddNewCourseBindingModel model)
        {
            string currentUserId = User.Identity.GetUserId();

            bool isAllowedToAddAcourse = this.service.IsAllowedToAddAcourse(currentUserId, model.OrganizationId);

            if (!isAllowedToAddAcourse)
            {
                throw new ArgumentException();
            }


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
            string currentUserId = User.Identity.GetUserId();

            bool isAllowedToModifyCourse = this.service.IsAllowedToModifyCourse(courseId, currentUserId);

            if (!isAllowedToModifyCourse)
            {
                throw new ArgumentException();
            }


            var editViewModel = this.service.GetEditCourseViewModel(courseId);

            return this.View(editViewModel);
        }



        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult Edit(EditCourseBindingModel model)
        {

            string currentUserId = User.Identity.GetUserId();

            bool isAllowedToModifyCourse = this.service.IsAllowedToModifyCourse(model.Id, currentUserId);

            if (!isAllowedToModifyCourse)
            {
                throw new ArgumentException();
            }

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
            string currentUserId = User.Identity.GetUserId();

            bool isAllowedToModifyCourse = this.service.IsAllowedToModifyCourse(courseId, currentUserId);

            if (!isAllowedToModifyCourse)
            {
                throw new ArgumentException();
            }

            var deleteCourseViewModel = this.service.GetDeleteCourseViewModel(courseId);

            return View(deleteCourseViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult Delete(DeleteCourseBindingModel model)
        {
            string currentUserId = User.Identity.GetUserId();

            bool isAllowedToModifyCourse = this.service.IsAllowedToModifyCourse(model.CourseId, currentUserId);

            if (!isAllowedToModifyCourse)
            {
                throw new ArgumentException();
            }

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
            string currentUserId = User.Identity.GetUserId();

            bool isAllowedToModifyCourse = this.service.IsAllowedToModifyCourse(courseId, currentUserId);

            if (!isAllowedToModifyCourse)
            {
                throw new ArgumentException();
            }

            var allCourseApplicationVms = this.service.GetManageCourseApplicationsViewModel(courseId);

            return View(allCourseApplicationVms);
        }



        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult ManageCourseApplications(ManageApplicationsWrapBindingModel model)
        {
            string currentUserId = User.Identity.GetUserId();

            bool isAllowedToModifyCourse = this.service.IsAllowedToModifyCourse(model.Applications[0].Course.CourseId, currentUserId);

            if (!isAllowedToModifyCourse)
            {
                throw new ArgumentException();
            }

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
            string currentUserId = User.Identity.GetUserId();

            bool isAllowedToModifyCourse = this.service.IsAllowedToModifyCourse(courseId, currentUserId);

            if (!isAllowedToModifyCourse)
            {
                throw new ArgumentException();
            }


            var applicationToDelete = this.service.GetDeleteCourseApplicationViewModel(courseId, currentUserId);

            return View(applicationToDelete);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult DeleteCourseApplication(DeleteCourseApplicationBindingModel model)
        {
            string currentUserId = User.Identity.GetUserId();

            bool isAllowedToModifyCourse = this.service.IsAllowedToModifyCourse(model.CourseId, currentUserId);

            if (!isAllowedToModifyCourse)
            {
                throw new ArgumentException();
            }

            if (this.ModelState.IsValid)
            {
                this.service.DeleteCourseApplication(model);

                return this.RedirectToAction("Details", "Profile");
            }

            var applicationToDelete = this.service.GetDeleteCourseApplicationViewModel(model.CourseId, currentUserId);

            return View(applicationToDelete);
        }

        [LeisureTimeAuthorize]
        public ActionResult RenderStudentCourses(int studentId)
        {
            string currentUserId = User.Identity.GetUserId();

            bool isOwnProfile = this.service.IsOwnProfile(studentId, currentUserId);

            if (!isOwnProfile)
            {
                throw new ArgumentException();
            }

            var coursesViewModels = this.service.GetCourseViewModelsByStudent(studentId);

            return this.PartialView(coursesViewModels);
        }


    }
}