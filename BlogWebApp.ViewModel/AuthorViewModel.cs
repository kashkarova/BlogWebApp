using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BlogWebApp.ViewModel
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("NFirst name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Nickname")]
        public string NickName { get; set; }

        [Required]
        [DisplayName("Age")]
        public int Age { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        public string Country { get; set; }

        [DisplayName("YYour favourite color")]
        public string FavouriteColor { get; set; }

        [DisplayName("Do you have pets?")]
        public bool? HavePets { get; set; }

        [DisplayName("Can you ride a bike?")]
        public bool? RideABike { get; set; }

        public virtual List<AuthorAndArticleViewModel> Articles { get; set; }
    }
}