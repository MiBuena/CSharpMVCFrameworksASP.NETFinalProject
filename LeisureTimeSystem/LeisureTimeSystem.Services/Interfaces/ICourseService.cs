using System.Collections.Generic;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.BidningModels.Applications;
using LeisureTimeSystem.Models.BidningModels.Course;
using LeisureTimeSystem.Models.ViewModels.Course;

namespace LeisureTimeSystem.Services.Interfaces
{
    public interface ICourseService
    {
        bool IsAllowedToModifyCourse(int courseId, string userId);
        bool IsAllowedToAddAcourse(string userId, int organizationId);
        bool IsCurrentUserAdministrator(string userId);
        bool IsOrganizationRepresentative(string userId, int organizationId);
        void DeleteCourse(DeleteCourseBindingModel model);
        DeleteCourseViewModel GetDeleteCourseViewModel(int courseId);
        void EditCourse(EditCourseBindingModel model);
        EditCourseViewModel GetEditCourseViewModel(int courseId);
        void AddNewCourse(AddNewCourseBindingModel model);
        AddNewCourseViewModel GetAddNewCourseViewModel(int organizationId);
        CourseApplicationViewModel GetChangeStatusApplicationViewModel(int studentId, int courseId);
        void ChangeStatus(ManageApplicationsWrapBindingModel model);
        ManageApplicationsWrapViewModel GetManageCourseApplicationsViewModel(int courseId);
        IEnumerable<CourseApplicationViewModel> GetAllCourseApplicationViewModels(int courseId);
        void DeleteCourseApplication(DeleteCourseApplicationBindingModel model);
        DeleteCourseApplicationViewModel GetDeleteCourseApplicationViewModel(int courseId, string userId);
        IEnumerable<CourseViewModel> GetCourseViewModelsByDiscipline(int disciplineId);
        ApplyViewModel GetApplyViewModel(int courseId, string userId);
        void SubmitApplication(ApplicationBindingModel applicationBindingModel);
        bool IsOwnProfile(int studentId, string userId);
    }
}