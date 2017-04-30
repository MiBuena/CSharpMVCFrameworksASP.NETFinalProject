using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Comment
{
    public class EditCommentViewModel
    {
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Please, enter comment.")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public virtual int ArticleId { get; set; }

        public virtual int AuthorId { get; set; }
    }
}
