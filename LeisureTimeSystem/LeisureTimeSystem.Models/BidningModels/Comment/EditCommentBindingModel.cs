using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels.Comment
{
    public class EditCommentBindingModel
    {
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Please, enter comment.")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public string LastChangeUserId { get; set; }

        public int ArticleId { get; set; }

    }
}
