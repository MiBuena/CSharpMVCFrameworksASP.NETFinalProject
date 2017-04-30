using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels.Comment;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels.Comment;

namespace LeisureTimeSystem.Services.Services
{
    public class CommentService : Service
    {
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

            this.Context.Entry(comment).CurrentValues.SetValues(model);

            this.Context.SaveChanges();
        }

        public EditCommentViewModel GetEditCommentViewModel(int commentId)
        {
            var comment = this.Context.Comments.Find(commentId);

            var editCommentViewModel = Mapper.Map<Comment, EditCommentViewModel>(comment);

            editCommentViewModel.CommentId = commentId;

            return editCommentViewModel;
        }

        public IEnumerable<ArticleCommentViewModel> GetAllArticleCommentViewModels(int articleId)
        {
            var comments = this.Context.Comments.Where(x => x.Article.Id == articleId);

            var commentsViewModels = Mapper.Map<IEnumerable<Comment>, IEnumerable<ArticleCommentViewModel>>(comments);

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
