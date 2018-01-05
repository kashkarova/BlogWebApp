using System;
using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.DAL.DbEntities
{
    public class ArticleAndTag : EntityBase
    {
        [Required]
        public Guid ArticleId { get; set; }

        [Required]
        public Guid TagId { get; set; }

        public virtual Article Article { get; set; }

        public virtual Tag Tag { get; set; }
    }
}