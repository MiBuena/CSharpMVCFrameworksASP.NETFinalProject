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
using LeisureTimeSystem.Models.ViewModels.Category;
using LeisureTimeSystem.Models.ViewModels.Course;
using LeisureTimeSystem.Models.ViewModels.Organization;
using LeisureTimeSystem.Models.ViewModels.Profile;

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

                expression.CreateMap<Address, EditAddressModelView>()
                                                    .ForMember(address => address.AddressId,
                        m => m.MapFrom(address => address.Id));

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

                expression.CreateMap<Course, DeleteCourseViewModel>()
                    .ForMember(course => course.OrganizationName,
                        m => m.MapFrom(course => course.Organization.Name));

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

                expression.CreateMap<Organization, OrganizationViewModel>();

                expression.CreateMap<Organization, EditOrganizationDataViewModel>()
                                .ForMember(organization => organization.Address,
        m => m.MapFrom(organization => organization.Address));


                expression.CreateMap<Organization, EditOrganizationDataBindingModel>();


                expression.CreateMap<EditOrganizationDataBindingModel, Organization>()
                                    .ForMember(organization => organization.Address,
                        m => m.MapFrom(organization => organization.Address));


                expression.CreateMap<Address, AddressBindingModel>();

                expression.CreateMap<AddressBindingModel, Address>()
                    .ForMember(address => address.Id,
                        m => m.MapFrom(address => address.AddressId));

                expression.CreateMap<Student, DetailsProfileViewModel>()
                                       .ForMember(organization => organization.City,
        m => m.MapFrom(organization => organization.Address.City))
                                .ForMember(student => student.Address,
        m => m.MapFrom(student => student.Address.ToString()));

                expression.CreateMap<Student, EditProfileViewModel>()
                .ForMember(student => student.Address,
        m => m.MapFrom(student => student.Address));


                expression.CreateMap<EditProfileBindingModel, Student>();

                expression.CreateMap<EditProfileBindingModel, Address>();

                expression.CreateMap<Organization, StudentProfileOrganizationViewModel>();




            });
        }
    }
}
