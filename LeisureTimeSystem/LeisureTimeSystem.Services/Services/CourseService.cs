using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;

namespace LeisureTimeSystem.Services.Services
{
    public class CourseService : Service
    {
        public IEnumerable<CourseViewModel> GetCourseViewModels(int disciplineId)
        {
            IEnumerable<Course> courses = this.Context.Courses.Where(x=>x.Discipline.Id == disciplineId).ToList();

            var courseViewModels = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);

            return courseViewModels;
        }

        public void SignUp(int courseId, int studentId)
        {
            var course = this.Context.Courses.Find(courseId);

            course.CoursesSubscriptionData.Add(new CourseApplicationData()
            {
                ApplicationMakerId = studentId,
                CourseId = courseId,
                StudentId = studentId
            });

            this.Context.SaveChanges();
        }
    }
}
