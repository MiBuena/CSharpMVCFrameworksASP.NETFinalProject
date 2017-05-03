using System.Collections.Generic;
using LeisureTimeSystem.Models.ViewModels;

namespace LeisureTimeSystem.Services.Interfaces
{
    public interface IDisciplineService
    {
        IEnumerable<DisciplineViewModel> GetDisciplineViewModels(int categoryId);
    }
}