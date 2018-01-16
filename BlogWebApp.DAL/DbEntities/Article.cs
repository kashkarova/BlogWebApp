using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApp.DAL.DbEntities
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string Title { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<ArticleAndTag> Tags { get; set; }

        public Article()
        {
            Id = Guid.NewGuid();
        }
    }
}