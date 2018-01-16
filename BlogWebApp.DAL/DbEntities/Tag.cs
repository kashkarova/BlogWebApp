using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.DAL.DbEntities
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        public virtual ICollection<ArticleAndTag> Articles { get; set; }

        public Tag()
        {
            Id = Guid.NewGuid();
        }
    }
}