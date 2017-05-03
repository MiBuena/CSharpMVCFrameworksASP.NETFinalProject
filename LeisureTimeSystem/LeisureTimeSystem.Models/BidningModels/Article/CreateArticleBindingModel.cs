using Microsoft.Build.Framework;

namespace LeisureTimeSystem.Models.BidningModels.Article
{
    public class CreateArticleBindingModel
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public NewArticleBindingModel NewArticle { get; set; }
    }
}
