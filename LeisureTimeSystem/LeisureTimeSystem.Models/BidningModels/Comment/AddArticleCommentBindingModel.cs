using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels.Comment
{
    public class AddArticleCommentBindingModel
    {
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(10000)]
        public string Body { get; set; }

        [Required]
        public virtual int ArticleId { get; set; }

        [Required]
        public virtual int AuthorId { get; set; }
    }
}
