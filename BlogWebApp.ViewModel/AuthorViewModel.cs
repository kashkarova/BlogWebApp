using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.ViewModel
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string NickName { get; set; }

        [Required]
        public int Age { get; set; }

        public string Gender { get; set; }

        public string Country { get; set; }

        public string FavouriteColor { get; set; }

        public bool? HavePets { get; set; }

        public bool? RideABike { get; set; }

        public virtual List<AuthorAndArticleViewModel> Articles { get; set; }
    }
}