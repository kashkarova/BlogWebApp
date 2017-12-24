using System;
using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.ViewModel
{
    public class AuthorAndArticleViewModel
    {
        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid ArticleId { get; set; }

        public virtual AuthorViewModel Author { get; set; }

        public virtual ArticleViewModel Article { get; set; }
    }
}