using System.Data.Entity;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogWebApp.DAL.DbContext
{
    public class BlogDb : IdentityDbContext<User>
    {
        public BlogDb() : base("BlogDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDb, Configuration>());
        }

        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleAndTag> ArticleAndTag { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Questionare> Questionare { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<UserAndArticle> UserAndArticle { get; set; }
    }
}