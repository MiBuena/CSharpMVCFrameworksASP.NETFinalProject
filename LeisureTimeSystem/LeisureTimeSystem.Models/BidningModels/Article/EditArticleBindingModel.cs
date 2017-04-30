using System.ComponentModel.DataAnnotations;

namespace LeisureTimeSystem.Models.BidningModels.Article
{
    public class EditArticleBindingModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Required]
        [StringLength(200)]
        public string TagsRaw { get; set; }

    }
}
