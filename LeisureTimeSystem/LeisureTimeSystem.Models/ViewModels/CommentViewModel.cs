﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.ViewModels.Student;

namespace LeisureTimeSystem.Models.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter comment.")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime TimeOfLastChange { get; set; }

        public virtual CommentAuthorViewModel Author { get; set; }

        public string AuthorOfLastChangeUsername { get; set; }
    }
}
