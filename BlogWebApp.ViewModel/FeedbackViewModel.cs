using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.ViewModel
{
    public class FeedbackViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [DisplayName("Date of publishing")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd'-'MM'-'yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(100)]
        public string Text { get; set; }
    }
}