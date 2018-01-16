using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.ViewModel.Models
{
    public class TagViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Tag")]
        public string Title { get; set; }

        public virtual List<ArticleAndTagViewModel> Articles { get; set; }
    }
}