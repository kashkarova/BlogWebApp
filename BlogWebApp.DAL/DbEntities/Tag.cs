using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.DAL.DbEntities
{
    public class Tag : EntityBase
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        public virtual ICollection<ArticleAndTag> Articles { get; set; }
    }
}