using System;
using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.ViewModel
{
    public class FeedbackViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(100)]
        public string Text { get; set; }
    }
}