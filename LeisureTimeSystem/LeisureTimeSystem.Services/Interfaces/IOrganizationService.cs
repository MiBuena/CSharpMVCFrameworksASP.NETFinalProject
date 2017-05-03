using System.Collections.Generic;
using System.Web;
using LeisureTimeSystem.Models.BidningModels;
using LeisureTimeSystem.Models.ViewModels.Organization;

namespace LeisureTimeSystem.Services.Interfaces
{
    public interface IOrganizationService
    {
        void RemoveRepresentative(RemoveRepresentativeBindingModel model);
        RemoveRepresentativeViewModel GetRemoveRepresentativeViewModel(int studentId, int organizationId);
        void AddRepresentative(AddRepresentativeBindingModel model);
        AddRepresentativeViewModel GetAddRepresentativeViewModel(int organizationId);
        ManageRepresentativesViewModel GetManageRepresentativesViewModel(int organizationId);
        void DeleteOrganization(int organizationId);
        DeleteOrganizationViewModel GetDeleteOrganizationViewModel(int organizationId);
        AllOrganizationCoursesViewModel GetAllOrganizationCourses(int organizationId);
        void UploadPicture(UploadOrganizationPictureBindingModel model, HttpPostedFileBase file, HttpServerUtilityBase server);
        UploadOrganizationPictureViewModel GetUploadOrganizationPictureViewModel(int organizationId);
        DeletePictureViewModel GetDeletePictureViewModel(int pictureId, int organizationId);
        void DeletePicture(DeletePictureBindingModel model);
        EditOrganizationDataViewModel GetEditOrganizationDataViewModel(int organizationId);
        EditOrganizationDescriptionViewModel GetEditOrganizationDescriptionViewModel(int organizationId);
        EditOrganizationPicturesViewModel GetEditOrganizationPicturesViewModel(int organizationId);
        void EditOrganizationData(EditOrganizationDataBindingModel model);
        void EditOrganizationDescription(EditOrganizationDescriptionBindingModel model);
        AddOrganizationViewModel GetViewModel();
        void CreateOrganization(AddOrganizationBindingModel model);
        ICollection<AddOrganizationDisciplineViewModel> GetDisciplinesViewModels();
        AllDisciplineOrganizationsViewModel GetAllOrganizationsViewModels(int disciplineId);
        DetailsOrganizationViewModel GetDetailsOrganizationViewModel(int organizationId, string userId);
        bool IsAuthorizedToModifyOrganization(string userId, int organizationId);
    }
}