﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApp.DAL.DbEntities
{
    public class ArticleAndTag
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Article))]
        public Guid ArticleId { get; set; }

        [Required]
        [ForeignKey(nameof(Tag))]
        public Guid TagId { get; set; }

        public virtual Article Article { get; set; }

        public virtual Tag Tag { get; set; }

        public ArticleAndTag()
        {
            Id = Guid.NewGuid();
        }
    }
}