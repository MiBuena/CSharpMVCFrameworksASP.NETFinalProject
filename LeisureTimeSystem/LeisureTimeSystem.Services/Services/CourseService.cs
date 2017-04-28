using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Models.ViewModels.Course;

namespace LeisureTimeSystem.Services.Services
{
    public class CourseService : Service
    {

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
            var application= this.Context.CoursesApplications.FirstOrDefault(x => x.CourseId == model.CourseId && x.StudentId == model.StudentId);

            this.Context.CoursesApplications.Remove(application);

            this.Context.SaveChanges();
        }

        public DeleteCourseViewModel GetDeleteCourseViewModel(int courseId, string userId)
        {
            var course = this.Context.Courses.Find(courseId);

            var courseViewModel = Mapper.Map<Course, DeleteCourseViewModel>(course);

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

        public IEnumerable<CourseViewModel> GetCourseViewModelsByStudent(int studentId)
        {
            IList<Course> courses = this.Context.Courses.Where(x => x.CoursesSubscriptionData.Any(y=>y.StudentId == studentId)).ToList();

            var courseViewModels = Mapper.Map<IList<Course>, IList<CourseViewModel>>(courses);

            for (int i = 0; i < courseViewModels.Count; i++)
            {
                courseViewModels[i].Status =
                    courses[i].CoursesSubscriptionData.FirstOrDefault(x => x.StudentId == studentId)
                        .Status;
            }


            return courseViewModels;
        }
    }
}
