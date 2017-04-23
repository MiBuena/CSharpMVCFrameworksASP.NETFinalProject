using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureTimeSystem.Services.Services;

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

        //public ActionResult ApplyPersonally(int course)
        //{
        //    var currentUser = 
        //}
    }
}