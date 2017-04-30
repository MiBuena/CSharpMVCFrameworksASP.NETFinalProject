using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels.Comment
{
    public class AddArticleCommentBindingModel
    {
        [Required(ErrorMessage = "Please, enter comment.")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public virtual int ArticleId { get; set; }

        public virtual int AuthorId { get; set; }
    }
}
