using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels.Article
{
    public class DeleteArticleBindingModel
    {
        [Required]
        public int ArticleId { get; set; }

    }
}
