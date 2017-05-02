using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LeisureTimeSystem.Attributes;
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


        [LeisureTimeAuthorize(Roles = "BlogAuthor")]
        public ActionResult Create()
        {
            string currentUserId = User.Identity.GetUserId();

            var createArticleViewModel = this.service.GetCreateArticleViewModel(currentUserId);

            return View(createArticleViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize(Roles = "BlogAuthor")]
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

        [LeisureTimeAuthorize(Roles = "BlogAuthor")]
        public ActionResult Edit(int articleId)
        {
            var editArticleViewModel = this.service.GetEditArticleViewModel(articleId);

            return View(editArticleViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize(Roles = "BlogAuthor")]
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

        [LeisureTimeAuthorize(Roles = "BlogAuthor")]
        public ActionResult Delete(int articleId)
        {
            var editArticleViewModel = this.service.GetDeleteArticleViewModel(articleId);

            return View(editArticleViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize(Roles = "BlogAuthor")]
        public ActionResult Delete(DeleteArticleBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.DeleteArticle(model);
                return this.RedirectToAction("All");
            }

            var deleteArticleViewModel = this.service.GetDeleteArticleViewModel(model.ArticleId);

            return View(deleteArticleViewModel);
        }

        public ActionResult Details(int articleId)
        {
            var detailsArticleViewModel = this.service.GetDetailsArticleViewModel(articleId);


            return View(detailsArticleViewModel);
        }

        public ActionResult ArticlesByTag(int tagId)
        {
            var articlesByTag = this.service.GetArticlesByTagViewModels(tagId);

            return View(articlesByTag);
        }

        [LeisureTimeAuthorize]
        public ActionResult AddALike(int articleId)
        {
            this.service.IncreaseLikeCounter(articleId);

            return this.RedirectToAction("Details", new {articleId = articleId});
        }

    }
}