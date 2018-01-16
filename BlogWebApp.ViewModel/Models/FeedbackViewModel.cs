using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.ViewModel.Models
{
    public class FeedbackViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [DisplayName("Date of publishing")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'-'MM'-'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(100)]
        public string Text { get; set; }
    }
}