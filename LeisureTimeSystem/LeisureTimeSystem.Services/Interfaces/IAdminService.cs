using LeisureTimeSystem.Models.BidningModels.Admin;
using LeisureTimeSystem.Models.ViewModels.Admin;

namespace LeisureTimeSystem.Services.Interfaces
{
    public interface IAdminService
    {
        void RemoveRole(string roleName, string userId);
        void SetRoles(SetRolesBindingModel setRolesBindingModel);
        SetRolesViewModel GetSetRolesViewModel();
    }
}