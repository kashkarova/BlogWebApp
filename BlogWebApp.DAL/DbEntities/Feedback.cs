﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.DAL.DbEntities
{
    public class Feedback : EntityBase
    {
        [Required]
        [MaxLength(20)]
        public string Author { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(100)]
        public string Text { get; set; }
    }
}