using System.Collections.Generic;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.ViewModels.Course;
using LeisureTimeSystem.Models.ViewModels.Profile;

namespace LeisureTimeSystem.Services.Interfaces
{
    public interface IProfileService
    {
        DetailsProfileViewModel GetProfileDetailsProfileViewModel(string currentUserId);
        EditProfileViewModel GetEditProfileViewModel(int studentId);
        void EditProfile(EditProfileBindingModel model);
        IEnumerable<StudentProfileOrganizationViewModel> GetOrganizations(int studentId);
        bool IsOwnProfile(int studentId, string userId);
        IEnumerable<CourseViewModel> GetCourseViewModelsByStudent(int studentId);
    }
}