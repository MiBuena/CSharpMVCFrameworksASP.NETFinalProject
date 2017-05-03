using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Article
{
    public class CreateArticleViewModel
    {
        [Required]
        public int StudentId { get; set; }

        public NewArticleViewModel NewArticle { get; set; }
    }
}
