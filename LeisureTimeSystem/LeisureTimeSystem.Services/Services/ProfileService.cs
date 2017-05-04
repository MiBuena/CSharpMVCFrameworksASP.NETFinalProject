using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Data.Interfaces;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.BidningModels.Address;
using LeisureTimeSystem.Models.BidningModels.Profile;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Models.ViewModels.Course;
using LeisureTimeSystem.Models.ViewModels.Profile;
using LeisureTimeSystem.Services.Interfaces;

namespace LeisureTimeSystem.Services.Services
{
    public class ProfileService : Service, IProfileService
    {
        public ProfileService(ILeisureTimeSystemDbContext context) : base(context)
        {
        }

        public DetailsProfileViewModel GetProfileDetailsProfileViewModel(string currentUserId)
        {
            var currentUser = this.Context.Users.Find(currentUserId);

           var student = this.Context.Students.Include(x=>x.Address).Include(y=>y.User).FirstOrDefault(x => x.UserId == currentUserId);

            var detailsProfileViewModel = Mapper.Map<Student, DetailsProfileViewModel>(student);

            detailsProfileViewModel.Username = currentUser.UserName;

            detailsProfileViewModel.Email = currentUser.Email;

            return detailsProfileViewModel;
        }

        public EditProfileViewModel GetEditProfileViewModel(int studentId)
        {
            var student = this.Context.Students.Include(x=>x.User).FirstOrDefault(y=>y.Id == studentId);

            var editProfileViewModel = Mapper.Map<Student, EditProfileViewModel>(student);

            editProfileViewModel.Username = student.User.UserName;

            editProfileViewModel.Email = student.User.Email;

            return editProfileViewModel;
        }

        public void EditProfile(EditProfileBindingModel model)
        {
            var student = this.Context.Students.Include(x=>x.Address).Include(x => x.User).FirstOrDefault(y => y.Id == model.Id);

            this.Context.SetModified(student, model);

            student.User.UserName = model.Username;
            student.User.Email = model.Email;

            UpdateAddress(model, student);

            this.Context.SaveChanges();
        }

        private void UpdateAddress(EditProfileBindingModel model, Student student)
        {
            Address address = Mapper.Map<AddressBindingModel, Address>(model.Address);

            if (student.Address == null)
            {
                this.Context.Addresses.Add(address);
                student.Address = address;
            }
            else
            {
                var studentAddress = student.Address;

                this.Context.SetModified(studentAddress, model.Address);
            }
        }

        public IEnumerable<StudentProfileOrganizationViewModel> GetOrganizations(int studentId)
        {
            var student = this.Context.Students.Find(studentId);

            var organizations = student.OrganizationsTheyRepresent;

            var organizationsVms =
                Mapper.Map<IEnumerable<Organization>, IEnumerable<StudentProfileOrganizationViewModel>>(organizations);

            return organizationsVms;

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

        public IEnumerable<CourseViewModel> GetCourseViewModelsByStudent(int studentId)
        {
            IList<Course> courses = this.Context.Courses.Where(x => x.CoursesSubscriptionData.Any(y => y.StudentId == studentId)).ToList();

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
