﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApp.DAL.DbEntities
{
    public class Article : EntityBase
    {
        [Required]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Title { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<AuthorAndArticle> Authors { get; set; }
    }
}