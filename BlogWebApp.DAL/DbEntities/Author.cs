using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApp.DAL.DbEntities
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string NickName { get; set; }

        [Required]
        [Range(1, 80)]
        public int Age { get; set; }

        [MaxLength(6)]
        public string Gender { get; set; }

        [MaxLength(15)]
        public string Country { get; set; }

        [MaxLength(20)]
        public string FavouriteColor { get; set; }

        public bool? HavePets { get; set; }

        public bool? RideABike { get; set; }

        public virtual ICollection<AuthorAndArticle> Articles { get; set; }

        public Author()
        {
            Id = Guid.NewGuid();
        }
    }
}