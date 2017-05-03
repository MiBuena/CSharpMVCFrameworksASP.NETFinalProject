using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeisureTimeSystem.Models.EntityModels
{
    public class Comment
    {
        public Comment()
        {
            this.Date = DateTime.Now;
            this.TimeOfLastChange = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public DateTime TimeOfLastChange { get; set; }

        [Required]
        public virtual Article Article { get; set; }

        public virtual Organization Organization { get; set; }

        [Required]
        public virtual Student Author { get; set; }

        public string AuthorOfLastChangeUsername { get; set; }
    }
}
