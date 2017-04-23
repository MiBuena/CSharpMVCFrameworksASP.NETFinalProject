using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeisureTimeSystem.Areas.Blog.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Blog/Articles
        public ActionResult Index()
        {
            return View();
        }
    }
}