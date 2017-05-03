using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.EntityModels;
using LeisureTimeSystem.Models.ViewModels.Pictures;
using LeisureTimeSystem.Models.ViewModels.Student;
using LeisureTimeSystem.Models.ViewModels.Tag;

namespace LeisureTimeSystem.Models.ViewModels.Article
{
    public class DetailsArticleViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Required]
        public virtual ArticleAuthorStudentViewModel Author { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int LikeCounter { get; set; }

        public virtual ICollection<CommentViewModel> Comments { get; set; }

        public virtual ICollection<TagViewModel> Tags { get; set; }

        public virtual ICollection<PictureViewModel> Pictures { get; set; }
    }
}
