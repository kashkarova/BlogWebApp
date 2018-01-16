using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogWebApp.DAL.DbEntities
{
    public class User : IdentityUser
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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}