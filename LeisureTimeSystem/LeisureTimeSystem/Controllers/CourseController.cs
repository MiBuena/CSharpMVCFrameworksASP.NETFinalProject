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
    public class CourseController : Controller
    {
        private CourseService service;

        public CourseController()
        {
            this.service = new CourseService();
        }

        //public ActionResult Add(int organizationId)
        //{

        //}

        //public ActionResult ChangeStatusApplication(int courseId, int studentId)
        //{
        //    var changeStatusViewModel = this.service.GetChangeStatusApplicationViewModel(studentId, courseId);

        //    return this.PartialView(changeStatusViewModel);
        //}

        [HttpPost]
        public ActionResult ChangeStatusApplication(ChangeStatusApplicationBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.ChangeStatus(model);
                return RedirectToAction("AllCourseApplications", new {studentId = model.StudentId, courseId = model.CourseId});
            }

            var changeStatusViewModel = this.service.GetChangeStatusApplicationViewModel(model.StudentId, model.CourseId);

            return this.PartialView(changeStatusViewModel);
        }

        public ActionResult AllCourseApplications(int courseId)
        {
            var allCourseApplicationVms = this.service.GetAllCourseApplicationViewModels(courseId);

            return View(allCourseApplicationVms);
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