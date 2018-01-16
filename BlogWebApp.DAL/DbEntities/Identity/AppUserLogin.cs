using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogWebApp.DAL.DbEntities.Identity
{
    public class AppUserLogin : IdentityUserLogin<Guid>
    {
    }
}