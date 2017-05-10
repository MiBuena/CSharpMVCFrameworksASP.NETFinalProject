using System.Collections.Generic;
using System.Security.Principal;
using LeisureTimeSystem.Models.BidningModels.Comment;
using LeisureTimeSystem.Models.ViewModels.Comment;

namespace LeisureTimeSystem.Services.Interfaces
{
    public interface ICommentService
    {
        bool IsAllowedToModifyTheComment(string userId, int commentId, IPrincipal user);
        bool IsCurrentUserAdministrator(string userId, IPrincipal user);
        bool IsAuthorOfTheComment(string userId, int commentId);
        DetailsCommentViewModel GetDetailsCommentViewModel(int commentId);
        void DeleteComment(DeleteCommentBindingModel model);
        DeleteCommentViewModel GetDeleteCommentViewModel(int commentId);
        void EditComment(EditCommentBindingModel model);
        EditCommentViewModel GetEditCommentViewModel(int commentId);
        IEnumerable<ArticleCommentViewModel> GetAllArticleCommentViewModels(int articleId, string currentUserId, IPrincipal user);
        void AddArticleComment(AddArticleCommentBindingModel model);
        AddArticleCommentViewModel GetAddArticleCommentViewModel(int articleId, string userId);
    }
}