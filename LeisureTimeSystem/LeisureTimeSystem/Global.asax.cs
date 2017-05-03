using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.BidningModels.Article;
using LeisureTimeSystem.Models.BidningModels.Comment;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Models.ViewModels.Admin;
using LeisureTimeSystem.Models.ViewModels.Article;
using LeisureTimeSystem.Models.ViewModels.Category;
using LeisureTimeSystem.Models.ViewModels.Comment;
using LeisureTimeSystem.Models.ViewModels.Course;
using LeisureTimeSystem.Models.ViewModels.Organization;
using LeisureTimeSystem.Models.ViewModels.Pictures;
using LeisureTimeSystem.Models.ViewModels.Profile;
using LeisureTimeSystem.Models.ViewModels.Student;
using LeisureTimeSystem.Models.ViewModels.Tag;
using Microsoft.AspNet.Identity.EntityFramework;

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

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();
        //    Server.ClearError();
        //    Response.Redirect("/Home/About");
        //}

        private void RegisterMaps()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Category, CategoryViewModel>()
                    .ForMember(category => category.SubCategoryViewModels,
                        m => m.MapFrom(category => category.Subcategories));

                expression.CreateMap<Discipline, DisciplineViewModel>();

                expression.CreateMap<Picture, EditPictureViewModel>();

                expression.CreateMap<Picture, DeletePictureViewModel>()
                                    .ForMember(picture => picture.PictureId,
                        m => m.MapFrom(picture => picture.Id));


                expression.CreateMap<Organization, EditOrganizationPicturesViewModel>()
                                    .ForMember(organization => organization.Pictures,
                        m => m.MapFrom(organization => organization.Pictures))
                                                            .ForMember(organization => organization.OrganizationId,
                        m => m.MapFrom(organization => organization.Id));

                expression.CreateMap<Organization, EditOrganizationDescriptionViewModel>();

                expression.CreateMap<Address, EditAddressModelView>()
                                                    .ForMember(address => address.AddressId,
                        m => m.MapFrom(address => address.Id));

                expression.CreateMap<Course, CourseViewModel>()
                    .ForMember(course => course.DisciplineName,
                        m => m.MapFrom(course => course.Discipline.Name))
                    .ForMember(course => course.OrganizationName,
                        m => m.MapFrom(course => course.Organization.Name));

                expression.CreateMap<NewCourseBindingModel, Course>();

                expression.CreateMap<NewCourseBindingModel, NewCourseViewModel>();

                expression.CreateMap<EditCourseBindingModel, Course>();

                expression.CreateMap<Course, EditCourseViewModel>()
                                    .ForMember(course => course.DisciplineId,
                        m => m.MapFrom(course => course.Discipline.Id));



                expression.CreateMap<Course, ApplyCourseViewModel>()
                    .ForMember(course => course.OrganizationName,
        m => m.MapFrom(course => course.Organization.Name));


                expression.CreateMap<Student, ApplyStudentViewModel>()
                                    .ForMember(student => student.Name,
        m => m.MapFrom(student => student.Name));

                expression.CreateMap<Course, ApplicationCourseViewModel>()
                                                    .ForMember(course => course.CourseId,
        m => m.MapFrom(course => course.Id));

                expression.CreateMap<Student, ApplicationStudentViewModel>()
                .ForMember(student => student.Username,
        m => m.MapFrom(student => student.User.UserName))
                        .ForMember(student => student.Email,
        m => m.MapFrom(student => student.DisplayEmail))
                                 .ForMember(student => student.StudentId,
        m => m.MapFrom(student => student.Id));

                expression.CreateMap<CourseApplicationData, CourseApplicationViewModel>()
                                                    .ForMember(data => data.Course,
        m => m.MapFrom(data => data.Course))
                                                            .ForMember(data => data.Student,
        m => m.MapFrom(data => data.Student));


                expression.CreateMap<AddressBindingModel, Address>();

                expression.CreateMap<Organization, DeleteOrganizationViewModel>();

                expression.CreateMap<Course, DeleteCourseViewModel>()
                                 .ForMember(course => course.CourseId,
        m => m.MapFrom(course => course.Id))
                                         .ForMember(course => course.OrganizationId,
        m => m.MapFrom(course => course.Organization.Id));


                expression.CreateMap<Student, RepresentativesStudentViewModel>()
                 .ForMember(student => student.Username,
        m => m.MapFrom(student => student.User.UserName));

                expression.CreateMap<Course, DeleteCourseApplicationViewModel>()
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


                expression.CreateMap<Address, AddressBindingModel>();

                expression.CreateMap<AddressBindingModel, Address>()
                    .ForMember(address => address.Id,
                        m => m.MapFrom(address => address.AddressId));

                expression.CreateMap<Student, DetailsProfileViewModel>()
                                       .ForMember(organization => organization.City,
        m => m.MapFrom(organization => organization.Address.City))
                                .ForMember(student => student.Address,
        m => m.MapFrom(student => student.Address.ToString()))
                                        .ForMember(student => student.DisplayEmail,
        m => m.MapFrom(student => student.DisplayEmail ?? student.User.Email));

                expression.CreateMap<Student, EditProfileViewModel>()
                .ForMember(student => student.Address,
        m => m.MapFrom(student => student.Address));


                expression.CreateMap<EditProfileBindingModel, Student>();

                expression.CreateMap<EditProfileBindingModel, Address>();

                expression.CreateMap<Organization, StudentProfileOrganizationViewModel>();


                expression.CreateMap<NewArticleBindingModel, Article>();

                expression.CreateMap<NewArticleBindingModel, NewArticleViewModel>();

                expression.CreateMap<Article, AllArticlesViewModel>().ForMember(article => article.CommentsCount,
                    m => m.MapFrom(article => article.Comments.Count));

                expression.CreateMap<Article, EditArticleViewModel>();

                expression.CreateMap<EditArticleBindingModel, Article>();

                expression.CreateMap<Article, DetailsArticleViewModel>()
                    .ForMember(article => article.Pictures,
                        m => m.MapFrom(article => article.Pictures))
                    .ForMember(article => article.Author,
                        m => m.MapFrom(article => article.Author))
                    .ForMember(article => article.Comments,
                        m => m.MapFrom(article => article.Comments))
                    .ForMember(article => article.Tags,
                        m => m.MapFrom(article => article.Tags));


                expression.CreateMap<Student, ArticleAuthorStudentViewModel>()
                    .ForMember(student => student.Username,
                        m => m.MapFrom(student => student.User.UserName));

                expression.CreateMap<Student, CommentAuthorViewModel>();

                expression.CreateMap<Tag, TagViewModel>();

                expression.CreateMap<Article, HomePageArticle>();


                expression.CreateMap<Course, CourseHomeViewModel>()
                                    .ForMember(course => course.OrganizationId,
                        m => m.MapFrom(course => course.Organization.Id));


                expression.CreateMap<Comment, CommentViewModel>()
                    .ForMember(comment => comment.Author,
                        m => m.MapFrom(comment => comment.Author));

                expression.CreateMap<Comment, EditCommentViewModel>()
                    .ForMember(comment => comment.AuthorId,
                        m => m.MapFrom(comment => comment.Author.Id))
                    .ForMember(comment => comment.ArticleId,
                        m => m.MapFrom(comment => comment.Article.Id));

                expression.CreateMap<EditCommentBindingModel, EditCommentViewModel>();

                expression.CreateMap<Comment, DeleteCommentViewModel>()
                                    .ForMember(comment => comment.ArticleId,
                        m => m.MapFrom(comment => comment.Article.Id))
                                            .ForMember(comment => comment.CommentId,
                        m => m.MapFrom(comment => comment.Id));


                expression.CreateMap<Tag, TagViewModel>();

                expression.CreateMap<Picture, PictureViewModel>();

                expression.CreateMap<Comment, ArticleCommentViewModel>()
                                    .ForMember(comment => comment.Author,
                        m => m.MapFrom(comment => comment.Author));

                expression.CreateMap<Comment, DetailsCommentViewModel>()
                    .ForMember(comment => comment.AuthorUsername,
                        m => m.MapFrom(comment => comment.Author.User.UserName))
                                         .ForMember(comment => comment.CommentedEntityId,
                        m => m.MapFrom(comment => comment.Article.Id));

                expression.CreateMap<Article, DeleteArticleViewModel>();

                expression.CreateMap<IdentityRole, RoleViewModel>();

                expression.CreateMap<ApplicationUser, PersonRoleViewModel>();




            });
        }
    }
}
