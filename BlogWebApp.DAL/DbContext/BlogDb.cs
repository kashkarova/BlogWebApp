using System.Data.Entity;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Migrations;

namespace BlogWebApp.DAL.DbContext
{
    public class BlogDb : System.Data.Entity.DbContext
    {
        public BlogDb() : base("BlogDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDb, Configuration>());
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<AuthorAndArticle> AuthorAndArticle { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<ArticleAndTag> ArticleAndTag { get; set; }
    }
}