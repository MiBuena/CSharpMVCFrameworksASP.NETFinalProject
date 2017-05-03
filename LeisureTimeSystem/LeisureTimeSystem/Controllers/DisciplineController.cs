using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeisureTimeSystem.Services.Interfaces;
using LeisureTimeSystem.Services.Services;

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