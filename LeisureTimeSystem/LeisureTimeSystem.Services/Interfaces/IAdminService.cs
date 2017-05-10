using LeisureTimeSystem.Models.BidningModels.Admin;
using LeisureTimeSystem.Models.Interfaces;
using LeisureTimeSystem.Models.ViewModels.Admin;

namespace LeisureTimeSystem.Services.Interfaces
{
    public interface IAdminService
    {
        void RemoveRole(string roleName, string userId, IApplicationUserManager userManager);
        void SetRoles(SetRolesBindingModel setRolesBindingModel, IApplicationUserManager userManager);
        SetRolesViewModel GetSetRolesViewModel();
    }
}