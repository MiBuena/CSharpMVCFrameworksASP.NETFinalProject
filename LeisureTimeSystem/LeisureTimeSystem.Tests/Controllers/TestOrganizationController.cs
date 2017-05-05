using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LeisureTimeSystem.Controllers;
using LeisureTimeSystem.Data.Interfaces;
using LeisureTimeSystem.Data.Mocks;
using LeisureTimeSystem.Models.BidningModels.Organization;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels.Organization;
using LeisureTimeSystem.Services.Interfaces;
using LeisureTimeSystem.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.FluentMVCTesting;


namespace LeisureTimeSystem.Tests.Controllers
{
    [TestClass]
    public class TestOrganizationController
    {
        private OrganizationController _controller;
        private IOrganizationService _service;
        private ILeisureTimeSystemDbContext _context;
        private Organization firstOrganization;
        private Organization secondOrganization;

        private Student firstStudent;
        private Student secondStudent;

        private Discipline discipline;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Organization, DeleteOrganizationViewModel>();
                expression.CreateMap<AddOrganizationBindingModel, Organization>()
                                                  .ForMember(organization => organization.Address,
      m => m.MapFrom(organization => organization.Address));

                expression.CreateMap<AddOrganizationBindingModel, AddOrganizationViewModel>();

                expression.CreateMap<Organization, DetailsOrganizationViewModel>()
                    .ForMember(organization => organization.DisciplineNames,
                        m => m.MapFrom(organization => organization.Disciplines.Select(x => x.Name)))
                    .ForMember(organization => organization.City,
                        m => m.MapFrom(organization => organization.Address.City))
                    .ForMember(organization => organization.Address,
                        m => m.MapFrom(organization => organization.Address.ToString()))
                    .ForMember(organization => organization.Pictures,
                        m => m.MapFrom(organization => organization.Pictures.Select(x => x.Path)))
                    .ForMember(organization => organization.AddressId,
                        m => m.MapFrom(organization => organization.Address.Id));


                expression.CreateMap<Discipline, AddOrganizationDisciplineViewModel>()
                .ForMember(discipline => discipline.Name,
        m => m.MapFrom(discipline => discipline.Name));

                expression.CreateMap<Organization, OrganizationViewModel>()
                                                .ForMember(organization => organization.Address,
        m => m.MapFrom(organization => organization.Address))
                                                        .ForMember(organization => organization.City,
        m => m.MapFrom(organization => organization.Address.City));

                expression.CreateMap<Organization, EditOrganizationDataViewModel>()
                                .ForMember(organization => organization.Address,
        m => m.MapFrom(organization => organization.Address));


                expression.CreateMap<Organization, EditOrganizationDataBindingModel>();


                expression.CreateMap<EditOrganizationDataBindingModel, Organization>()
                                    .ForMember(organization => organization.Address,
                        m => m.MapFrom(organization => organization.Address));

                expression.CreateMap<Organization, EditOrganizationPicturesViewModel>()
                                 .ForMember(organization => organization.Pictures,
                     m => m.MapFrom(organization => organization.Pictures))
                                                         .ForMember(organization => organization.OrganizationId,
                     m => m.MapFrom(organization => organization.Id));

                expression.CreateMap<Organization, EditOrganizationDescriptionViewModel>();

            });

        }

        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();

            this.firstOrganization = new Organization()
            {
                Name = "Athletic",
                Representatives = new HashSet<Student>()
            };

            this.secondOrganization = new Organization()
            {
                Name = "Champion",
                Representatives = new HashSet<Student>()
            };

            this.firstStudent = new Student()
            {
                Id = 1,
                Name = "FirstStudent",
                OrganizationsTheyRepresent = new HashSet<Organization>()
            };

            this.secondStudent = new Student()
            {
                Id = 2,
                Name = "SecondStudent",
                OrganizationsTheyRepresent = new HashSet<Organization>()
            };

            this.discipline = new Discipline()
            {
                Id = 1,
                Name = "Sports"
            };




            this._context = new FakeLeisureTimeDbContext();


            this._service = new OrganizationService(this._context);

            this._controller = new OrganizationController(this._service);

            this._context.Organizations.Add(this.firstOrganization);

            this._context.Organizations.Add(this.secondOrganization);

            this._context.Students.Add(this.firstStudent);
            this._context.Students.Add(this.secondStudent);

            this.discipline.Organizations.Add(this.firstOrganization);
            this.discipline.Organizations.Add(this.secondOrganization);

            this.firstOrganization.Disciplines = new HashSet<Discipline>();

            this.firstOrganization.Disciplines.Add(this.discipline);


            this.secondOrganization.Disciplines = new HashSet<Discipline>();

            this.secondOrganization.Disciplines.Add(this.discipline);

            this._context.Disciplines.Add(this.discipline);
        }

        [TestMethod]
        public void AddRepresentatives_ShouldPass()
        {
            _controller.WithCallTo(c => c.All(1)).ShouldRenderDefaultView()
.WithModel<AllDisciplineOrganizationsViewModel>(m => m.OrganizationViewModels!=null);
        }

        [TestMethod]
        public void All_ShouldPass()
        {
            _controller.WithCallTo(c => c.All(1)).ShouldRenderDefaultView()
.WithModel<AllDisciplineOrganizationsViewModel>(m => m.OrganizationViewModels.Count() == 2);

        }

        [TestMethod]
        public void All_ModelProperties_ShouldPass()
        {
            _controller.WithCallTo(c => c.All(1)).ShouldRenderDefaultView()
.WithModel<AllDisciplineOrganizationsViewModel>(m => m.OrganizationViewModels.FirstOrDefault().Name == "Athletic");

        }


    }
}
