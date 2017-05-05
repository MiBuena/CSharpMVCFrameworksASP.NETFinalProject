using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using LeisureTimeSystem.Controllers;
using LeisureTimeSystem.Data.Interfaces;
using LeisureTimeSystem.Data.Mocks;
using LeisureTimeSystem.Models.BidningModels.Course;
using LeisureTimeSystem.Models.BidningModels.Organization;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Models.ViewModels.Course;
using LeisureTimeSystem.Models.ViewModels.Organization;
using LeisureTimeSystem.Services.Interfaces;
using LeisureTimeSystem.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.FluentMVCTesting;


namespace LeisureTimeSystem.Tests.Controllers
{
    [TestClass]
    public class TestCourseController
    {
        private CourseController _controller;
        private ICourseService _service;
        private ILeisureTimeSystemDbContext _context;
        private Discipline firstDiscipline;
        private Discipline secondDiscipline;
        private Course firstCourse;
        private Course secondCourse;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Discipline, DisciplineViewModel>();
                expression.CreateMap<Course, CourseViewModel>()
    .ForMember(course => course.DisciplineName,
        m => m.MapFrom(course => course.Discipline.Name))
    .ForMember(course => course.OrganizationName,
        m => m.MapFrom(course => course.Organization.Name));

            });

        }

        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();

            this.firstDiscipline = new Discipline()
            {
                Id = 1,
                Name = "Sports"
            };

            this.secondDiscipline = new Discipline()
            {
                Id = 2,
                Name = "Arts"
            };


            this.firstCourse = new Course()
            {
                Id = 1,
                Name = "Acting",
                Discipline = this.firstDiscipline,
                MaximumNumberOfParticipants = 10,
                StartDate = new DateTime(2017, 04, 01),
                EndDate = new DateTime(2017, 04, 20),
                SubscriptionDeadLine = new DateTime(2017, 04, 01)
            };

            this.secondCourse = new Course
            {
                Id = 2,
                Name = "Introduction to running",
                Discipline = this.secondDiscipline,
                MaximumNumberOfParticipants = 10,
                StartDate = new DateTime(2017, 04, 01),
                EndDate = new DateTime(2017, 04, 20),
                SubscriptionDeadLine = new DateTime(2017, 04,01)
            };



            this._context = new FakeLeisureTimeDbContext();


            this._service = new CourseService(this._context);

            this._controller = new CourseController(this._service);

            this._context.Disciplines.Add(this.firstDiscipline);

            this._context.Disciplines.Add(this.secondDiscipline);

            this._context.Courses.Add(this.firstCourse);

            this._context.Courses.Add(this.secondCourse);


        }

        [TestMethod]
        public void DisciplineCourses_ShouldPass()
        {
            _controller.WithCallTo(c => c.DisciplineCourses(1)).ShouldRenderDefaultView()
.WithModel<IEnumerable<CourseViewModel>>(m => m != null);
        }




    }
}
