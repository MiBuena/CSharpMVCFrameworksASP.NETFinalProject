using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;

namespace LeisureTimeSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Category, CategoryViewModel>()
                    .ForMember(category => category.SubCategoryViewModels,
                        m => m.MapFrom(category => category.Subcategories));

                expression.CreateMap<Discipline, DisciplineViewModel>();

                expression.CreateMap<Course, CourseViewModel>()
                                    .ForMember(course => course.DisciplineName,
                        m => m.MapFrom(course => course.Discipline.Name))
                        .ForMember(course => course.OrganizationName,
                        m => m.MapFrom(course => course.Organization.Name));

                expression.CreateMap<Course, ApplyCourseViewModel>()
                    .ForMember(course => course.OrganizationName,
        m => m.MapFrom(course => course.Organization.Name));


                expression.CreateMap<Student, ApplyStudentViewModel>()
                                    .ForMember(student => student.Name,
        m => m.MapFrom(student => student.Name));

                expression.CreateMap<AddressBindingModel, Address>();


                expression.CreateMap<AddOrganizationBindingModel, Organization>()
                                                    .ForMember(organization => organization.Address,
        m => m.MapFrom(organization => organization.Address));

                expression.CreateMap<AddOrganizationBindingModel, AddOrganizationViewModel>();

                expression.CreateMap<Discipline, AddOrganizationDisciplineViewModel>()
                .ForMember(discipline => discipline.Name,
        m => m.MapFrom(discipline => discipline.Name));

                expression.CreateMap<Organization, OrganizationViewModel>();

                expression.CreateMap<Student, DetailsProfileViewModel>();



            });
        }
    }
}
