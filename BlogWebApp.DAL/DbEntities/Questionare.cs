using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApp.DAL.DbEntities
{
    public class Questionare
    {
        [Key]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string FavouriteColor { get; set; }

        public bool? HavePets { get; set; }

        public bool? RideABike { get; set; }

        public virtual User User { get; set; }
    }
}