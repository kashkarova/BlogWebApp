using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApp.DAL.DbEntities
{
    public class UserAndArticle
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Article))]
        public Guid ArticleId { get; set; }

        public virtual User User { get; set; }

        public virtual Article Article { get; set; }

        public UserAndArticle()
        {
            Id = Guid.NewGuid();
        }
    }
}