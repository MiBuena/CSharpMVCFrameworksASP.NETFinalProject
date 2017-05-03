using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels.Comment
{
    public class EditCommentBindingModel
    {
        [Required]
        public int CommentId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public string LastChangeUserId { get; set; }

        public int ArticleId { get; set; }

    }
}
