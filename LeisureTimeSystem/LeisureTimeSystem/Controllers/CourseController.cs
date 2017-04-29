using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels;
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

        public ActionResult Add(int organizationId)
        {
            var addNewCourseViewModel = this.service.GetAddNewCourseViewModel(organizationId);

            return View(addNewCourseViewModel);
        }

        [HttpPost]
        public ActionResult Add(AddNewCourseBindingModel model)
        {
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

        public ActionResult Edit(int courseId)
        {
            var editViewModel = this.service.GetEditCourseViewModel(courseId);

            return this.View(editViewModel);
        }



        [HttpPost]
        public ActionResult Edit(EditCourseBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditCourse(model);
                return this.RedirectToAction("ManageOrganizationCourses", "Organization", new {organizationId = model.OrganizationId});
            }

            var editViewModel = this.service.GetEditCourseViewModel(model.Id);

            return this.View(editViewModel);
        }



        public ActionResult ManageCourseApplications(int courseId)
        {
            var allCourseApplicationVms = this.service.GetAllCourseApplicationViewModels(courseId);

            return View(allCourseApplicationVms);
        }

        [HttpPost]
        public ActionResult ManageCourseApplications(ChangeStatusApplicationBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.ChangeStatus(model);
                return RedirectToAction("ManageCourseApplications", new { studentId = model.StudentId, courseId = model.CourseId });
            }

            var changeStatusViewModel = this.service.GetAllCourseApplicationViewModels(model.CourseId);

            return this.PartialView(changeStatusViewModel);
        }

        public ActionResult DisciplineCourses(int disciplineId)
        {
            var courses = this.service.GetCourseViewModelsByDiscipline(disciplineId);

            return View(courses);
        }

        public ActionResult Apply(int courseId)
        {
            string currentUserId = User.Identity.GetUserId();

            var applyViewModel = this.service.GetApplyViewModel(courseId, currentUserId);

            return View(applyViewModel);
        }

        [HttpPost]
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

        public ActionResult DeleteCourseApplication(int courseId)
        {
            string currentUserId = User.Identity.GetUserId();

            var applicationToDelete = this.service.GetDeleteCourseViewModel(courseId, currentUserId);

            return View(applicationToDelete);
        }

        [HttpPost]
        public ActionResult DeleteCourseApplication(DeleteCourseApplicationBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.DeleteCourseApplication(model);

                return this.RedirectToAction("Details", "Profile");
            }

            string currentUserId = User.Identity.GetUserId();

            var applicationToDelete = this.service.GetDeleteCourseViewModel(model.CourseId, currentUserId);

            return View(applicationToDelete);
        }

        public ActionResult RenderStudentCourses(int studentId)
        {
            var coursesViewModels = this.service.GetCourseViewModelsByStudent(studentId);

            return this.PartialView(coursesViewModels);
        }


    }
}