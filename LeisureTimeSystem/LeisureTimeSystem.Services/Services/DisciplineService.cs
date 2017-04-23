using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels;

namespace LeisureTimeSystem.Services.Services
{
    public class DisciplineService : Service
    {
        public IEnumerable<DisciplineViewModel> GetDisciplineViewModels(int categoryId)
        {
            var disciplines = this.Context.Disciplines.Where(x => x.Category.Id == categoryId).ToList();

            var disciplineViewModels = Mapper.Map<IEnumerable<Discipline>, IEnumerable<DisciplineViewModel>>(disciplines);


            return disciplineViewModels;
        }

    }
}
