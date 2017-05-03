using System.Collections.Generic;
using LeisureTimeSystem.Models.BidningModels.Comment;
using LeisureTimeSystem.Models.ViewModels.Comment;

namespace LeisureTimeSystem.Services.Interfaces
{
    public interface ICommentService
    {
        bool IsAllowedToModifyTheComment(string userId, int commentId);
        bool IsCurrentUserAdministrator(string userId);
        bool IsAuthorOfTheComment(string userId, int commentId);
        DetailsCommentViewModel GetDetailsCommentViewModel(int commentId);
        void DeleteComment(DeleteCommentBindingModel model);
        DeleteCommentViewModel GetDeleteCommentViewModel(int commentId);
        void EditComment(EditCommentBindingModel model);
        EditCommentViewModel GetEditCommentViewModel(int commentId);
        IEnumerable<ArticleCommentViewModel> GetAllArticleCommentViewModels(int articleId, string currentUserId);
        void AddArticleComment(AddArticleCommentBindingModel model);
        AddArticleCommentViewModel GetAddArticleCommentViewModel(int articleId, string userId);
    }
}