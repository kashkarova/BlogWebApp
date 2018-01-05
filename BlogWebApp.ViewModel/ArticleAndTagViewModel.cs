using System;
using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.ViewModel
{
    public class ArticleAndTagViewModel
    {
        [Required]
        public Guid ArticleId { get; set; }

        [Required]
        public Guid TagId { get; set; }

        public virtual ArticleViewModel Article { get; set; }

        public virtual TagViewModel Tag { get; set; }
    }
}
