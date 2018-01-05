using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApp.ViewModel
{
    public class ArticleViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Title of article")]
        [Index(IsUnique = true)]
        public string Title { get; set; }

        [DisplayName("Description of article")]
        public string Description { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'-'MM'-'yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of publishing")]
        public DateTime Date { get; set; }

        [DisplayName("Hashtags")]
        public List<string> HashTags { get; set; }

        public virtual List<AuthorAndArticleViewModel> Authors { get; set; }

        public virtual List<ArticleAndTagViewModel> Tags { get; set; }

        public ArticleViewModel()
        {
            HashTags = new List<string>();
        }
    }
}