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
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd'-'MM'-'yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [DisplayName("Date of publishing")]
        public DateTime Date { get; set; }

        public virtual List<AuthorAndArticleViewModel> Authors { get; set; }
    }
}