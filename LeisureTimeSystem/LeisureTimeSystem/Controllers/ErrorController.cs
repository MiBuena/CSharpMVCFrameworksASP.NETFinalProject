using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeisureTimeSystem.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(HandleErrorInfo model)
        {
            return View("Error", model);
        }
    }
}