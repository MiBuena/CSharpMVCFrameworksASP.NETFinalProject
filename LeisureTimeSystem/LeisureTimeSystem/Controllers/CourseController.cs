using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult DisciplineCourses(int disciplineId)
        {
            var courses = this.service.GetCourseViewModels(disciplineId);
            return View(courses);
        }

        public ActionResult Apply(int courseId)
        {
            string currentUserId = User.Identity.GetUserId();

            var applyViewModel = this.service.GetApplyViewModel(courseId, currentUserId);

            return View(applyViewModel);
        }
    }
}