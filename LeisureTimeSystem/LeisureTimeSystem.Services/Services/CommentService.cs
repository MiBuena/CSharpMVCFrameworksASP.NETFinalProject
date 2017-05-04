using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using AutoMapper;
using LeisureTimeSystem.Data.Interfaces;
using LeisureTimeSystem.Models.BidningModels.Comment;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels.Comment;
using LeisureTimeSystem.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace LeisureTimeSystem.Services.Services
{
    public class CommentService : Service, ICommentService
    {
        public CommentService(ILeisureTimeSystemDbContext context) : base(context)
        {
        }

        public bool IsAllowedToModifyTheComment(string userId, int commentId)
        {
            bool isAuthorOfTheComment = this.IsAuthorOfTheComment(userId, commentId);

            bool isUserAdministrator = this.IsCurrentUserAdministrator(userId);

            return isAuthorOfTheComment || isUserAdministrator;
        }

        public bool IsCurrentUserAdministrator(string userId)
        {
            if (this.UserManager.IsInRole(userId, "Administrator"))
            {
                return true;
            }

            return false;
        }

        public bool IsAuthorOfTheComment(string userId, int commentId)
        {
            var comment = this.Context.Comments.Include(x => x.Author.User).FirstOrDefault(x => x.Id == commentId);

            if (comment.Author.User.Id == userId)
            {
                return true;
            }

            return false;
        }

        public DetailsCommentViewModel GetDetailsCommentViewModel(int commentId)
        {
            var comment = this.Context.Comments.Find(commentId);

            var commentViewModel = Mapper.Map<Comment, DetailsCommentViewModel>(comment);

            return commentViewModel;
        }

        public void DeleteComment(DeleteCommentBindingModel model)
        {
            var comment = this.Context.Comments.Find(model.CommentId);

            this.Context.Comments.Remove(comment);

            this.Context.SaveChanges();
        }

        public DeleteCommentViewModel GetDeleteCommentViewModel(int commentId)
        {
            var comment = this.Context.Comments.Find(commentId);

            var commentViewModel = Mapper.Map<Comment, DeleteCommentViewModel>(comment);

            return commentViewModel;
        }


        public void EditComment(EditCommentBindingModel model)
        {
            var comment = this.Context.Comments.Find(model.CommentId);

            comment.TimeOfLastChange = DateTime.Now;

            var authorOfLastChange = this.Context.Users.Find(model.LastChangeUserId);

            comment.AuthorOfLastChangeUsername = authorOfLastChange.UserName;

            this.Context.SetModified(comment, model);

            var article = this.Context.Articles.Find(model.ArticleId);

            comment.Article = article;


            this.Context.SaveChanges();
        }


        public EditCommentViewModel GetEditCommentViewModel(int commentId)
        {
            var comment = this.Context.Comments.Find(commentId);

            var editCommentViewModel = Mapper.Map<Comment, EditCommentViewModel>(comment);

            editCommentViewModel.CommentId = commentId;

            return editCommentViewModel;
        }

        public IEnumerable<ArticleCommentViewModel> GetAllArticleCommentViewModels(int articleId, string currentUserId)
        {
            var comments = this.Context.Comments.Where(x => x.Article.Id == articleId).OrderByDescending(y => y.Date);

            var commentsViewModels = Mapper.Map<IEnumerable<Comment>, IEnumerable<ArticleCommentViewModel>>(comments);

            foreach (var commentViewModel in commentsViewModels)
            {
                bool isAllowedToModify = this.IsAllowedToModifyTheComment(currentUserId, commentViewModel.Id);

                commentViewModel.IsAllowedToModify = isAllowedToModify;
            }

            return commentsViewModels;
        }

        public void AddArticleComment(AddArticleCommentBindingModel model)
        {
            var student = this.Context.Students.Find(model.AuthorId);

            var article = this.Context.Articles.Find(model.ArticleId);

            var comment = new Comment()
            {
                Body = model.Body,
                Article = article,
                Author = student
            };

            this.Context.Comments.Add(comment);

            this.Context.SaveChanges();

        }

        public AddArticleCommentViewModel GetAddArticleCommentViewModel(int articleId, string userId)
        {
            var student = this.Context.Students.FirstOrDefault(x => x.UserId == userId);

            AddArticleCommentViewModel model = new AddArticleCommentViewModel()
            {
                ArticleId = articleId,
                AuthorId = student.Id
            };

            return model;
        }


    }
}
