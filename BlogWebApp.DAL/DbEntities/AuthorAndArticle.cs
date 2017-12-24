using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApp.DAL.DbEntities
{
    public class AuthorAndArticle : EntityBase
    {
        [Required]
        [ForeignKey("Author")]
        public Guid AuthorId { get; set; }

        [Required]
        [ForeignKey("Article")]
        public Guid ArticleId { get; set; }

        public virtual Author Author { get; set; }

        public virtual Article Article { get; set; }
    }
}