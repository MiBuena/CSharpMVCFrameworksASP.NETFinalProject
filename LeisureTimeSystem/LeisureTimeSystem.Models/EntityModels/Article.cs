﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeisureTimeSystem.Models.EntityModels.AbstractClasses;
using LeisureTimeSystem.Models.EntityModels.Interfaces;

namespace LeisureTimeSystem.Models.EntityModels
{
    public class Article
    {

        public Article()
        {
            this.Comments = new HashSet<Comment>();
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
            this.Date = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(10000)]
        public string Body { get; set; }

        [Required]
        [StringLength(200)]
        public string TagsRaw { get; set; }

        [Required]
        public virtual Student Author { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public virtual Picture Picture { get; set; }

        public int LikeCounter { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
