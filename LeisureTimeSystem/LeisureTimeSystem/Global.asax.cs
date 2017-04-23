﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
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
                        m => m.MapFrom(course => course.Discipline.Name));

                expression.CreateMap<Course, ApplyCourseViewModel>()
                    .ForMember(course => course.OrganizationName,
        m => m.MapFrom(course => course.Organization.Name));


                expression.CreateMap<Student, ApplyStudentViewModel>();

            });
        }
    }
}
