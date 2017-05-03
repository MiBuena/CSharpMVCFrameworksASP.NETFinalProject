using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.ViewModels.Article
{
    public class HomePageArticle
    {
        private string body;

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        public string Body
        {
            get
            {
                if (this.body.Length > 400)
                {
                    return this.body.Substring(0, 400) + "...";
                }

                return this.body;
            }
            set
            {
                this.body = value;
            }
        }

        public string PicturePath { get; set; }
    }
}
