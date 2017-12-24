using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.ViewModel
{
    public class ArticleViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual List<AuthorAndArticleViewModel> Authors { get; set; }
    }
}