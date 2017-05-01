using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.BidningModels.Course;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.Enums;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Models.ViewModels.Course;
using Microsoft.AspNet.Identity;

namespace LeisureTimeSystem.Services.Services
{
    public class CourseService : Service
    {

        public bool IsAllowedToModifyCourse(int courseId, string userId)
        {
            var organization = this.Context.Organizations.FirstOrDefault(x => x.Courses.Any(y => y.Id == courseId));

            bool isOrganizationRepresentative = this.IsOrganizationRepresentative(userId, organization.Id);

            bool isAdministrator = this.IsCurrentUserAdministrator(userId);

            return isAdministrator || isOrganizationRepresentative;
        }


        public bool IsAllowedToAddAcourse(string userId, int organizationId)
        {
            bool isAdministrator = this.IsCurrentUserAdministrator(userId);

            bool isOrganizationRepresentative = this.IsOrganizationRepresentative(userId, organizationId);

            return isAdministrator || isOrganizationRepresentative;
        }

        public bool IsCurrentUserAdministrator(string userId)
        {
            if (this.UserManager.IsInRole(userId, "Administrator"))
            {
                return true;
            }

            return false;
        }

        public bool IsOrganizationRepresentative(string userId, int organizationId)
        {
            var organization = this.Context.Organizations.Find(organizationId);

            if (organization.Representatives.Any(x => x.UserId == userId))
            {
                return true;
            }

            return false;
        }

        public void DeleteCourse(DeleteCourseBindingModel model)
        {
            var course = this.Context.Courses.Find(model.CourseId);

            this.Context.Courses.Remove(course);

            this.Context.SaveChanges();
        }

        public DeleteCourseViewModel GetDeleteCourseViewModel(int courseId)
        {
            var course = this.Context.Courses.Find(courseId);

            var courseViewModel = Mapper.Map<Course, DeleteCourseViewModel>(course);

            return courseViewModel;
        }

        public void EditCourse(EditCourseBindingModel model)
        {
            var discipline = this.Context.Disciplines.Find(model.DisciplineId);


            var courseFromDB = this.Context.Courses.Find(model.Id);

            courseFromDB.Discipline = discipline;


            this.Context.Entry(courseFromDB).CurrentValues.SetValues(model);

            this.Context.SaveChanges();
        }

        public EditCourseViewModel GetEditCourseViewModel(int courseId)
        {
            var course = this.Context.Courses.Find(courseId);

            var courseViewModel = Mapper.Map<Course, EditCourseViewModel>(course);

            var disciplies = this.Context.Disciplines;

            var disciplinesViewModels = Mapper.Map<IEnumerable<Discipline>, IEnumerable<DisciplineViewModel>>(disciplies);

            courseViewModel.Disciplines = disciplinesViewModels;

            return courseViewModel;
        }

        public void AddNewCourse(AddNewCourseBindingModel model)
        {
            var course = Mapper.Map<NewCourseBindingModel, Course>(model.Course);

            var organization = this.Context.Organizations.Find(model.OrganizationId);

            var discipline = this.Context.Disciplines.Find(model.DisciplineId);

            course.Organization = organization;

            course.Discipline = discipline;

            this.Context.Courses.Add(course);

            this.Context.SaveChanges();
        }

        public AddNewCourseViewModel GetAddNewCourseViewModel(int organizationId)
        {
            var disciplies = this.Context.Disciplines;

            var organization = this.Context.Organizations.Find(organizationId);

            var disciplinesViewModels = Mapper.Map<IEnumerable<Discipline>, IEnumerable<DisciplineViewModel>>(disciplies);

            AddNewCourseViewModel model = new AddNewCourseViewModel()
            {
                Disciplines = disciplinesViewModels,
                OrganizationId = organizationId,
                OrganizationName = organization.Name
            };

            return model;
        }

        public CourseApplicationViewModel GetChangeStatusApplicationViewModel(int studentId, int courseId)
        {
            var course = this.Context.Courses.Find(courseId);

            var courseViewModel = Mapper.Map<Course, ApplicationCourseViewModel>(course);

            var student = this.Context.Students.Include(x => x.User).FirstOrDefault(y => y.Id == studentId);

            var studentViewModel = Mapper.Map<Student, ApplicationStudentViewModel>(student);

            var application =
                this.Context.CoursesApplications.FirstOrDefault(x => x.CourseId == courseId && x.StudentId == studentId);

            CourseApplicationViewModel model = new CourseApplicationViewModel()
            {
                Course = courseViewModel,
                Student = studentViewModel,
                Status = application.Status
            };

            return model;
        }



        public void ChangeStatus(ManageApplicationsWrapBindingModel model)
        {
            foreach (var applicationModel in model.Applications)
            {
                var application = this.Context.CoursesApplications.FirstOrDefault(x => x.CourseId == applicationModel.Course.CourseId && x.StudentId == applicationModel.Student.StudentId);

                application.Status = applicationModel.Status;
            }

            this.Context.SaveChanges();
        }

        public ManageApplicationsWrapViewModel GetManageCourseApplicationsViewModel(int courseId)
        {
            var courseApplications = this.Context.CoursesApplications.Include(x=>x.Student).Include(x=>x.Course).Where(x => x.CourseId == courseId).ToList();


            var courseApplicationsViewModels = Mapper.Map<List<CourseApplicationData>, List<CourseApplicationViewModel>>(courseApplications);

            ManageApplicationsWrapViewModel model = new ManageApplicationsWrapViewModel()
            {
                Applications = courseApplicationsViewModels
            };

            return model;
        }

        public IEnumerable<CourseApplicationViewModel> GetAllCourseApplicationViewModels(int courseId)
        {
            var courseApplications = this.Context.CoursesApplications.Where(x => x.CourseId == courseId);

            var courseApplicationsVms =
                Mapper.Map<IEnumerable<CourseApplicationData>, IEnumerable<CourseApplicationViewModel>>(
                    courseApplications);

            return courseApplicationsVms;
        }

        public void DeleteCourseApplication(DeleteCourseApplicationBindingModel model)
        {
            var application = this.Context.CoursesApplications.FirstOrDefault(x => x.CourseId == model.CourseId && x.StudentId == model.StudentId);

            this.Context.CoursesApplications.Remove(application);

            this.Context.SaveChanges();
        }

        public DeleteCourseApplicationViewModel GetDeleteCourseApplicationViewModel(int courseId, string userId)
        {
            var course = this.Context.Courses.Find(courseId);

            var courseViewModel = Mapper.Map<Course, DeleteCourseApplicationViewModel>(course);

            var student = this.Context.Students.FirstOrDefault(x => x.UserId == userId);

            courseViewModel.StudentId = student.Id;

            return courseViewModel;
        }

        public IEnumerable<CourseViewModel> GetCourseViewModelsByDiscipline(int disciplineId)
        {
            IEnumerable<Course> courses = this.Context.Courses.Where(x => x.Discipline.Id == disciplineId).ToList();

            var courseViewModels = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);

            return courseViewModels;
        }

        public ApplyViewModel GetApplyViewModel(int courseId, string userId)
        {
            var course = this.Context.Courses.Find(courseId);

            var student = this.Context.Students.FirstOrDefault(x => x.UserId == userId);

            ApplyCourseViewModel applyCourseViewModel = Mapper.Map<Course, ApplyCourseViewModel>(course);

            ApplyStudentViewModel applyStudentViewModel = Mapper.Map<Student, ApplyStudentViewModel>(student);

            ApplyViewModel vm = new ApplyViewModel()
            {
                ApplyCourseViewModel = applyCourseViewModel,
                ApplyStudentViewModel = applyStudentViewModel,
            };

            return vm;
        }

        public void SubmitApplication(ApplicationBindingModel applicationBindingModel)
        {
            var course = this.Context.Courses.Find(applicationBindingModel.CourseId);

            course.CoursesSubscriptionData.Add(new CourseApplicationData()
            {
                CourseId = applicationBindingModel.CourseId,
                StudentId = applicationBindingModel.StudentId
            });

            this.Context.SaveChanges();
        }



        public bool IsOwnProfile(int studentId, string userId)
        {
            var student = this.Context.Students.FirstOrDefault(x => x.UserId == userId);

            if (student.Id == studentId)
            {
                return true;
            }

            return false;
        }
    }
}
