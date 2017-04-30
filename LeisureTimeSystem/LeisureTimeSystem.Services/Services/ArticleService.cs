using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeisureTimeSystem.Models.BidningModels.Article;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels.Article;

namespace LeisureTimeSystem.Services.Services
{
    public class ArticleService : Service
    {
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

            this.Context.Entry(dbArticle).CurrentValues.SetValues(article);

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


        public ICollection<AllArticlesViewModel> GetAllArticlesViewModels()
        {

            ICollection<AllArticlesViewModel> collection = new HashSet<AllArticlesViewModel>();

            var articles = this.Context.Articles;

            foreach (var article in articles)
            {
                var articleViewModel = Mapper.Map<Article, AllArticlesViewModel>(article);

                collection.Add(articleViewModel);
            }

            return collection;
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

