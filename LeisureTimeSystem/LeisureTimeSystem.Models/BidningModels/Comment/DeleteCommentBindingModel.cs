using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels.Comment
{
    public class DeleteCommentBindingModel
    {
        [Required]
        public int CommentId { get; set; }

        public int ArticleId { get; set; }
    }
}
