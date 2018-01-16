using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogWebApp.DAL.DbEntities.Identity
{
    public class AppUser : IdentityUser<Guid, AppUserLogin, AppUserRole, AppUserClaim>
    {
        [Required]
        [Range(1, 99)]
        public int Age { get; set; }

        [MaxLength(6)]
        public string Gender { get; set; }

        [MaxLength(20)]
        public string Country { get; set; }

        public virtual Questionare Questionare { get; set; }

        public virtual ICollection<UserAndArticle> Articles { get; set; }
    }
}