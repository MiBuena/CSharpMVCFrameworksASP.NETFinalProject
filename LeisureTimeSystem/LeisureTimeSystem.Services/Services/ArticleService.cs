using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using AutoMapper;
using LeisureTimeSystem.Data.Interfaces;
using LeisureTimeSystem.Models.BidningModels.Article;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels.Article;
using LeisureTimeSystem.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace LeisureTimeSystem.Services.Services
{
    public class ArticleService : Service, IArticleService
    {
        public ArticleService(ILeisureTimeSystemDbContext context) : base(context)
        {
        }

        public bool IsAuthorizedToModifyArticle(string userId, int articleId)
        {
            var article = this.Context.Articles.Include(x => x.Author.User).FirstOrDefault(y => y.Id == articleId);

            var isAdministrator = this.UserManager.IsInRole(userId, "Administrator");

            var isArticleAuthor = article.Author.UserId == userId;

            return isArticleAuthor || isAdministrator;
        }

        public void DeleteArticle(DeleteArticleBindingModel model)
        {
            var article = this.Context.Articles.Find(model.ArticleId);

            this.Context.Articles.Remove(article);

            this.Context.SaveChanges();
        }

        public DeleteArticleViewModel GetDeleteArticleViewModel(int articleId)
        {
            var article = this.Context.Articles.Find(articleId);

            var articleViewModel = Mapper.Map<Article, DeleteArticleViewModel>(article);

            return articleViewModel;
        }


        public DetailsArticleViewModel GetDetailsArticleViewModel(int articleId)
        {
            var article = this.Context.Articles.Find(articleId);

            var detailsArticleViewModel = Mapper.Map<Article, DetailsArticleViewModel>(article);

            return detailsArticleViewModel;
        }

        public void EditArticle(EditArticleBindingModel model)
        {
            var article = Mapper.Map<EditArticleBindingModel, Article>(model);

            ICollection<string> tagsNames = model.TagsRaw.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var tagName in tagsNames)
            {
                var tag = this.Context.Tags.FirstOrDefault(x => x.Name == tagName);

                article.Tags.Add(tag);
            }

            var dbArticle = this.Context.Articles.Find(model.Id);

            ClearAllPresentTags(dbArticle);


            dbArticle.Tags = new HashSet<Tag>(article.Tags);

            this.Context.SetModified(dbArticle, article);

            this.Context.SaveChanges();
        }

        private void ClearAllPresentTags(Article article)
        {
            article.Tags.Clear();

            if (this.Context.Tags.Any(x => x.Articles.Any(y => y.Id == article.Id)))
            {
                var tag = this.Context.Tags.FirstOrDefault(x => x.Articles.Any(y => y.Id == article.Id));

                tag.Articles.Remove(article);
            }

            this.Context.SaveChanges();

        }

        public EditArticleViewModel GetEditArticleViewModel(int articleId)
        {
            var article = this.Context.Articles.Find(articleId);

            var editArticleViewModel = Mapper.Map<Article, EditArticleViewModel>(article);

            return editArticleViewModel;
        }

        public ICollection<AllArticlesViewModel> GetArticlesByTagViewModels(int tagId)
        {
            ICollection<AllArticlesViewModel> collection = new HashSet<AllArticlesViewModel>();

            var articles = this.Context.Articles.Where(x=>x.Tags.Any(y=>y.Id == tagId));

            foreach (var article in articles)
            {
                var articleViewModel = Mapper.Map<Article, AllArticlesViewModel>(article);

                collection.Add(articleViewModel);
            }

            return collection;
        }


        public ICollection<AllArticlesViewModel> GetAllArticlesViewModels(string currentUserId)
        {
            ICollection<AllArticlesViewModel> collection = new HashSet<AllArticlesViewModel>();

            var articles = this.Context.Articles.Include(x=>x.Author.User);

            foreach (var article in articles)
            {
                var articleViewModel = Mapper.Map<Article, AllArticlesViewModel>(article);

                var isCurrentUserAuthorizedToModify = IsAuthorizedToModify(currentUserId, article);

                articleViewModel.IsAllowedToModify = isCurrentUserAuthorizedToModify;

                collection.Add(articleViewModel);
            }

            return collection;
        }

        public bool IsAuthorizedToModify(string currentUserId, Article article)
        {
            var isArticleAuthor = this.IsArticleAuthor(currentUserId, article);

            bool isAdministrator = this.UserManager.IsInRole(currentUserId, "Administrator");

            return isArticleAuthor || isAdministrator;
        }

        public bool IsArticleAuthor(string currentUserId, Article article)
        {
            if (article.Author.User.Id == currentUserId)
            {
                return true;
            }

            return false;
        }


        public void UpdateTags(string rawTags)
        {
            ICollection<string> tagsNames = rawTags.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var tagName in tagsNames)
            {
                if (!this.Context.Tags.Any(tag => tag.Name == tagName))
                {
                    CreateTag(tagName);
                }
            }
        }

        private void CreateTag(string tagName)
        {
            Tag newTag = new Tag()
            {
                Name = tagName
            };

            this.Context.Tags.Add(newTag);

            this.Context.SaveChanges();
        }

        public CreateArticleViewModel GetErrorArticleViewModel(CreateArticleBindingModel model)
        {
            var articleViewModel = Mapper.Map<NewArticleBindingModel, NewArticleViewModel>(model.NewArticle);

            CreateArticleViewModel createNewArticleViewModel = new CreateArticleViewModel()
            {
                NewArticle = articleViewModel,
                StudentId = model.StudentId
            };

            return createNewArticleViewModel;
        }

        public void CreateArticle(CreateArticleBindingModel model)
        {
            var newArticle = Mapper.Map<NewArticleBindingModel, Article>(model.NewArticle);

            var author = this.Context.Students.Find(model.StudentId);

            newArticle.Author = author;

            ICollection<string> tagsNames = model.NewArticle.TagsRaw.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var tagName in tagsNames)
            {
                var tag = this.Context.Tags.FirstOrDefault(x => x.Name == tagName);

                newArticle.Tags.Add(tag);
            }

            this.Context.Articles.Add(newArticle);

            this.Context.SaveChanges();
        }


        public CreateArticleViewModel GetCreateArticleViewModel(string userId)
        {
            var studentId = this.Context.Students.FirstOrDefault(x => x.UserId == userId).Id;

            CreateArticleViewModel model = new CreateArticleViewModel()
            {
                StudentId = studentId
            };

            return model;
        }
    }
}

