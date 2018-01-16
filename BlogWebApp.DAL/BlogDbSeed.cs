using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogWebApp.DAL
{
    public static class BlogDbSeed
    {
        public static void SeedUsersAndRoles(BlogDb context)
        {
            //set roles
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var adminRole = new IdentityRole { Name = "Administrator" };
            roleManager.Create(adminRole);

            var userRole = new IdentityRole { Name = "User" };
            roleManager.Create(userRole);
            //

            //registrate users
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            var admin = new User()
            {
                UserName = "admin",
                Email = "admin@admin.com",
                PhoneNumber = "+380660000000",
                Age = 25,
                Gender = "Male",
                Country = "Ukraine"
            };

            userManager.Create(admin, "adminadmin");
            userManager.AddToRole(admin.Id, "Administrator");

            var user = new User()
            {
                UserName = "Tetiana",
                Email = "kashkarovatany@gmail.com",
                PhoneNumber = "+380660000000",
                Age = 22,
                Gender = "Female",
                Country = "Ukraine"
            };

            userManager.Create(user, "password");
            userManager.AddToRole(user.Id, "User");

            context.SaveChanges();
            //

            //add questionaries to registrated users
            var adminQuestionare = new Questionare()
            {
                UserId = admin.Id,
                FirstName = "Ivan",
                LastName = "Ivanov",
                FavouriteColor = "blue",
                HavePets = true,
                RideABike = true
            };

            var userQuestionare = new Questionare()
            {
                UserId = user.Id,
                FirstName = "Tetiana",
                LastName = "Kashkarova",
                FavouriteColor = "white"
            };

            context.Questionare.Add(adminQuestionare);
            context.Questionare.Add(userQuestionare);
            context.SaveChanges();
            //
        }
    }
}