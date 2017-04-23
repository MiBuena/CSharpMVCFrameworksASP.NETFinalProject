using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;

namespace LeisureTimeSystem.Services.Services
{
    public class CourseService : Service
    {
        public IEnumerable<CourseViewModel> GetCourseViewModels(int disciplineId)
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
    }
}
