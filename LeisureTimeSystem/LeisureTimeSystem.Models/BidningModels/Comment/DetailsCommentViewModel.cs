using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.EntityModels;

namespace LeisureTimeSystem.Models.BidningModels.Comment
{
    public class DetailsCommentViewModel
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public DateTime TimeOfLastChange { get; set; }

        [Required]
        public string AuthorUsername { get; set; }

        [Required]
        public string AuthorOfLastChangeUsername { get; set; }

        public int CommentedEntityId { get; set; }
    }
}
