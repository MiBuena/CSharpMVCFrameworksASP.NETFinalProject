using System.Security.Principal;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Models.ViewModels.Home;

namespace LeisureTimeSystem.Services.Interfaces
{
    public interface IHomeService
    {
        HomePageViewModel GetHomePageViewModel();
        NavbarViewModel GetNavbarViewModel(string currentUserId, IPrincipal user);
    }
}