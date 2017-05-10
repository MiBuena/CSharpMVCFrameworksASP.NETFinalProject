using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using LeisureTimeSystem.Controllers;
using LeisureTimeSystem.Data.Interfaces;
using LeisureTimeSystem.Data.Mocks;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Services.Interfaces;
using LeisureTimeSystem.Services.Services;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;


namespace LeisureTimeSystem.Tests.Controllers
{
    [TestClass]
    public class TestDisciplineController
    {
        private DisciplineController _controller;
        private IDisciplineService _service;
        private ILeisureTimeSystemDbContext _context;
        private List<Discipline> disciplines;
        private Category category;


        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Discipline, DisciplineViewModel>();
            });

        }

        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();

            this.category = new Category()
            {
                Id = 1,
                Name = "Sport"
            };

            this.disciplines = new List<Discipline>()
            {
                new Discipline()
                {
                    Id = 1,
                    Name = "Wrestling",
                    Category = this.category
                },
                new Discipline()
                {
                    Id = 2,
                    Name = "Football",
                    Category = this.category
                },


            };

            this._context = new FakeLeisureTimeDbContext();

            foreach (var discipline in this.disciplines)
            {
                this._context.Disciplines.Add(discipline);
            }

            this._service = new DisciplineService(this._context);

            this._controller = new DisciplineController(this._service);
        }

        [TestMethod]
        public void ShowDisciplines()
        {
            _controller.WithCallTo(c => c.ShowDisciplines(1)).ShouldRenderDefaultView()
    .WithModel<IEnumerable<DisciplineViewModel>>(m => m!=null);
        }

        [TestMethod]
        public void ShowDisciplines_DisciplinesCount_ShouldPass()
        {
            _controller.WithCallTo(c => c.ShowDisciplines(1)).ShouldRenderDefaultView()
.WithModel<IEnumerable<DisciplineViewModel>>(m => m.Count() == 2);

        }

        [TestMethod]
        public void ShowDisciplines_DisciplineName_ShouldPass()
        {
            _controller.WithCallTo(c => c.ShowDisciplines(1)).ShouldRenderDefaultView()
.WithModel<IEnumerable<DisciplineViewModel>>(m => m.FirstOrDefault().Name == "Wrestling");

            _controller.WithCallTo(c => c.ShowDisciplines(1)).ShouldRenderDefaultView()
.WithModel<IEnumerable<DisciplineViewModel>>(m => m.LastOrDefault().Name == "Football");

        }



    }
}
