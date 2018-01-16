using System;
using System.Data.Entity.Migrations;
using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;

namespace BlogWebApp.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BlogDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
        }

        // Filling generated DB entities by test data
        protected override void Seed(BlogDb context)
        {
            BlogDbSeed.SeedUsersAndRoles(context);

            context.Article.AddOrUpdate(x => x.Title,
                new Article
                {
                    Title = "The border between good and evil",
                    Description = "Cicero was bored",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    Date = DateTime.Now
                },
                new Article
                {
                    Title = "Second",
                    Description = "First article",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    Date = DateTime.Now
                },
                new Article
                {
                    Title = "Third",
                    Description = "Abracadabra",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante." +
                           "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    Date = DateTime.Now
                },
                new Article
                {
                    Title = "Fourth",
                    Description = "Article",
                    Text = "Text",
                    Date = DateTime.Now
                }
            );

            context.Tag.AddOrUpdate(x => x.Title,
                new Tag
                {
                    Title = "#tag"
                },
                new Tag
                {
                    Title = "#instagram"
                },
                new Tag
                {
                    Title = "#blog"
                },
                new Tag
                {
                    Title = "#tag2"
                }
            );
        }
    }
}