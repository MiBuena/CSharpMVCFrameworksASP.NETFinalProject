using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LeisureTimeSystem.Attributes;
using LeisureTimeSystem.Models.BidningModels.Comment;
using LeisureTimeSystem.Models.ViewModels.Comment;
using LeisureTimeSystem.Services.Services;
using Microsoft.AspNet.Identity;

namespace LeisureTimeSystem.Controllers
{
    public class CommentController : Controller
    {
        private CommentService service;

        public CommentController()
        {
            this.service = new CommentService();
        }

        [LeisureTimeAuthorize]
        public ActionResult Edit(int commentId)
        {
            string currentUserId = User.Identity.GetUserId();

            var isAllowedToModifyTheComment = this.service.IsAllowedToModifyTheComment(currentUserId, commentId);

            if (!isAllowedToModifyTheComment)
            {
               throw new ArgumentException(); 
            }

            var editCommentViewModel = this.service.GetEditCommentViewModel(commentId);

            return this.View(editCommentViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult Edit(EditCommentBindingModel model)
        {
            string currentUserId = User.Identity.GetUserId();

            var isAllowedToModifyTheComment = this.service.IsAllowedToModifyTheComment(currentUserId, model.CommentId);

            if (!isAllowedToModifyTheComment)
            {
                throw new ArgumentException();
            }

            if (this.ModelState.IsValid)
            {
                model.LastChangeUserId = currentUserId;

                this.service.EditComment(model);

                return this.RedirectToAction("Details", "Articles", new {articleId = model.ArticleId, area = "Blog"});
             }

            var commentViewModel = Mapper.Map<EditCommentBindingModel, EditCommentViewModel>(model);

            return this.View(commentViewModel);
        }

        [LeisureTimeAuthorize]
        public ActionResult Delete(int commentId)
        {
            string currentUserId = User.Identity.GetUserId();

            var isAllowedToModifyTheComment = this.service.IsAllowedToModifyTheComment(currentUserId, commentId);

            if (!isAllowedToModifyTheComment)
            {
                throw new ArgumentException();
            }

            var commentViewModel = this.service.GetDeleteCommentViewModel(commentId);

            return this.View(commentViewModel);
        }

        [HttpPost]
        public ActionResult Delete(DeleteCommentBindingModel model)
        {
            string currentUserId = User.Identity.GetUserId();

            var isAllowedToModifyTheComment = this.service.IsAllowedToModifyTheComment(currentUserId, model.CommentId);

            if (!isAllowedToModifyTheComment)
            {
                throw new ArgumentException();
            }


            if (this.ModelState.IsValid)
            {
                this.service.DeleteComment(model);

                return this.RedirectToAction("Details", "Articles", new {articleId = model.ArticleId, area = "Blog"});
            }

            var commentViewModel = this.service.GetDeleteCommentViewModel(model.CommentId);

            return this.View(commentViewModel);
        }

        public ActionResult Details(int commentId)
        {
            var editCommentViewModel = this.service.GetDetailsCommentViewModel(commentId);

            return this.View(editCommentViewModel);
        }

        [LeisureTimeAuthorize]
        public ActionResult AddArticleComment(int articleId)
        {
            string currentUserId = User.Identity.GetUserId();

            var addArticleCommentViewModel = this.service.GetAddArticleCommentViewModel(articleId, currentUserId);

            return this.PartialView(addArticleCommentViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult AddArticleComment(AddArticleCommentBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddArticleComment(model);

                return this.PartialView(null);
            }

            string currentUserId = User.Identity.GetUserId();

            var addArticleCommentViewModel = this.service.GetAddArticleCommentViewModel(model.ArticleId, currentUserId);

            addArticleCommentViewModel.Body = model.Body;

            return this.PartialView(addArticleCommentViewModel);

        }

        public ActionResult AllArticleComments(int articleId)
        {
            var commentsViewModels = this.service.GetAllArticleCommentViewModels(articleId);

            return this.PartialView(commentsViewModels);
        }
    }
}