using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;
using LeisureTimeSystem.Services.Interfaces;

namespace LeisureTimeSystem.Services.Services
{
    public class DisciplineService : Service, IDisciplineService
    {
        public IEnumerable<DisciplineViewModel> GetDisciplineViewModels(int categoryId)
        {
            var disciplines = this.Context.Disciplines.Where(x => x.Category.Id == categoryId).ToList();

            var disciplineViewModels = Mapper.Map<IEnumerable<Discipline>, IEnumerable<DisciplineViewModel>>(disciplines);


            return disciplineViewModels;
        }

    }
}
