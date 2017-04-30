using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels.Article;
using LeisureTimeSystem.Models.ViewModels.Article;
using LeisureTimeSystem.Services.Services;
using Microsoft.AspNet.Identity;

namespace LeisureTimeSystem.Areas.Blog.Controllers
{
    public class ArticlesController : Controller
    {
        private ArticleService service;

        public ArticlesController()
        {
            this.service = new ArticleService();
        }

        // GET: Blog/Articles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            string currentUserId = User.Identity.GetUserId();

            var createArticleViewModel = this.service.GetCreateArticleViewModel(currentUserId);

            return View(createArticleViewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateArticleBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.UpdateTags(model.NewArticle.TagsRaw);

                this.service.CreateArticle(model);

                return this.RedirectToAction("All");
            }

            var createNewArticleViewModel = this.service.GetErrorArticleViewModel(model);

            return View(createNewArticleViewModel);
        }


        public ActionResult All()
        {
            var allArticlesViewModels = this.service.GetAllArticlesViewModels();

            return View(allArticlesViewModels);
        }

        public ActionResult Edit(int articleId)
        {
            var editArticleViewModel = this.service.GetEditArticleViewModel(articleId);

            return View(editArticleViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EditArticleBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.UpdateTags(model.TagsRaw);

                this.service.EditArticle(model);

                return this.RedirectToAction("Details", new {articleId = model.Id});
            }

            var editArticleViewModel = Mapper.Map<EditArticleBindingModel, EditArticleViewModel>(model);

            return View(editArticleViewModel);
        }

        public ActionResult Details(int articleId)
        {
            return View();
        }

    }
}