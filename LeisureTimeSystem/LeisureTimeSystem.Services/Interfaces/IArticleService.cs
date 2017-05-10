using System.Collections.Generic;
using System.Security.Principal;
using LeisureTimeSystem.Models.BidningModels.Article;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels.Article;

namespace LeisureTimeSystem.Services.Interfaces
{
    public interface IArticleService
    {
        bool IsAuthorizedToModifyArticle(string userId, int articleId, IPrincipal user);
        void DeleteArticle(DeleteArticleBindingModel model);
        DeleteArticleViewModel GetDeleteArticleViewModel(int articleId);
        DetailsArticleViewModel GetDetailsArticleViewModel(int articleId);
        void EditArticle(EditArticleBindingModel model);
        EditArticleViewModel GetEditArticleViewModel(int articleId);
        ICollection<AllArticlesViewModel> GetArticlesByTagViewModels(int tagId);
        ICollection<AllArticlesViewModel> GetAllArticlesViewModels(string currentUserId, IPrincipal user);
        bool IsAuthorizedToModify(string currentUserId, Article article, IPrincipal user);
        bool IsArticleAuthor(string currentUserId, Article article);
        void UpdateTags(string rawTags);
        CreateArticleViewModel GetErrorArticleViewModel(CreateArticleBindingModel model);
        void CreateArticle(CreateArticleBindingModel model);
        CreateArticleViewModel GetCreateArticleViewModel(string userId);
    }
}