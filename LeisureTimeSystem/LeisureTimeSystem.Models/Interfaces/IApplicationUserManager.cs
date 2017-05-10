using Microsoft.AspNet.Identity;

namespace LeisureTimeSystem.Models.Interfaces
{
    public interface IApplicationUserManager
    {
        IdentityResult RemoveFromRole(string userId, string userRole);

        IdentityResult AddToRole(string userId, string userRole);
    }
}
