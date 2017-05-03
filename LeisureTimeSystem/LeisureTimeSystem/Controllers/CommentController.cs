using System.Web.Mvc;
using AutoMapper;
using LeisureTimeSystem.Attributes;
using LeisureTimeSystem.Exceptions;
using LeisureTimeSystem.Models.BidningModels.Comment;
using LeisureTimeSystem.Models.ViewModels.Comment;
using LeisureTimeSystem.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Constants = LeisureTimeSystem.Models.Utils.Constants;

namespace LeisureTimeSystem.Controllers
{
    [HandleError(ExceptionType = typeof (NotAuthorizedException), View = "Error")]
    public class CommentController : Controller
    {
        private ICommentService service;

        public CommentController(ICommentService service)
        {
            this.service = service;
        }

        [LeisureTimeAuthorize]
        public ActionResult Edit(int commentId)
        {
            CheckIfUserIsAuthorizedToModifyThisComment(commentId);

            var editCommentViewModel = this.service.GetEditCommentViewModel(commentId);

            return this.View(editCommentViewModel);
        }



        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult Edit(EditCommentBindingModel model)
        {
            CheckIfUserIsAuthorizedToModifyThisComment(model.CommentId);

            if (this.ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();

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
            CheckIfUserIsAuthorizedToModifyThisComment(commentId);

            var commentViewModel = this.service.GetDeleteCommentViewModel(commentId);

            return this.View(commentViewModel);
        }

        [HttpPost]
        [LeisureTimeAuthorize]
        public ActionResult Delete(DeleteCommentBindingModel model)
        {
            CheckIfUserIsAuthorizedToModifyThisComment(model.CommentId);

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
            string currentUserId = User.Identity.GetUserId();

            var commentsViewModels = this.service.GetAllArticleCommentViewModels(articleId, currentUserId);

            return this.PartialView(commentsViewModels);
        }

        private void CheckIfUserIsAuthorizedToModifyThisComment(int commentId)
        {
            string currentUserId = User.Identity.GetUserId();

            var isAllowedToModifyTheComment = this.service.IsAllowedToModifyTheComment(currentUserId, commentId);

            if (!isAllowedToModifyTheComment)
            {
                throw new NotAuthorizedException(Constants.ModifyCommentsExceptionMessage);
            }
        }
    }
}
