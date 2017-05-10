using System.Web.Mvc;
using LeisureTimeSystem.Services.Interfaces;

namespace LeisureTimeSystem.Controllers
{
    public class DisciplineController : Controller
    {
        private IDisciplineService service;

        public DisciplineController(IDisciplineService service)
        {
            this.service = service;
        }



        public ActionResult ShowDisciplines(int categoryId)
        {
            var viewModels = this.service.GetDisciplineViewModels(categoryId);

            return View(viewModels);
        }

    }
}