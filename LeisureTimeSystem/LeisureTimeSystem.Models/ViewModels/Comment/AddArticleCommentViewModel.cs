using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Comment
{
    public class AddArticleCommentViewModel
    {
        [Required(ErrorMessage = "Please, enter comment.")]
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Required]
        public virtual int ArticleId { get; set; }

        [Required]
        public virtual int AuthorId { get; set; }
    }
}
