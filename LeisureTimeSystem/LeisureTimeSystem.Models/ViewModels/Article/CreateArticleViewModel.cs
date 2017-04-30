using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.ViewModels.Article
{
    public class CreateArticleViewModel
    {
        public int StudentId { get; set; }

        public NewArticleViewModel NewArticle { get; set; }
    }
}
