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
        }

        protected override void Seed(BlogDb context)
        {
            context.Author.AddOrUpdate(x => x.NickName,
                new Author
                {
                    FirstName = "Tetiana",
                    LastName = "Kashkarova",
                    NickName = "Tanya",
                    Age = 22
                },
                new Author
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    NickName = "Vanya",
                    Age = 22
                },
                new Author
                {
                    FirstName = "Petr",
                    LastName = "Petrov",
                    NickName = "Pervyi",
                    Age = 22
                },
                new Author
                {
                    FirstName = "Sydor",
                    LastName = "Sydorov",
                    NickName = "Sydor",
                    Age = 22
                },
                new Author
                {
                    FirstName = "Somebody",
                    LastName = "Somebody",
                    NickName = "Anonym",
                    Age = 22
                }
            );

            context.Feedback.AddOrUpdate(x => x.Author,
                new Feedback
                {
                    Author = "Petya",
                    Text = "Best of the best!",
                    Date = DateTime.Now
                },
                new Feedback
                {
                    Author = "Vasya",
                    Text = "Worst of the worst!",
                    Date = DateTime.Now
                },
                new Feedback
                {
                    Author = "Kolya",
                    Text = "Ja ne reshaju",
                    Date = DateTime.Now
                },
                new Feedback
                {
                    Author = "I don`t know",
                    Text = "I don`t know",
                    Date = DateTime.Now
                }
            );

            context.Article.AddOrUpdate(x => x.Title,
                new Article
                {
                    Title = "First",
                    Description = "First article",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    Date = DateTime.Now
                },
                new Article
                {
                    Title = "Second",
                    Description = "First article",
                    Text = "Text",
                    Date = DateTime.Now
                },
                new Article
                {
                    Title = "Third",
                    Description = "First article",
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.",
                    Date = DateTime.Now
                },
                new Article
                {
                    Title = "Fourth",
                    Description = "First article",
                    Text = "Text",
                    Date = DateTime.Now
                }
            );
        }
    }
}