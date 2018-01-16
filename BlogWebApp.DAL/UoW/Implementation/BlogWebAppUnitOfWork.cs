using System;
using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Interfaces;
using BlogWebApp.DAL.UoW.Interface;

namespace BlogWebApp.DAL.UoW.Implementation
{
    public class BlogWebAppUnitOfWork :
        IBlogWebAppUnitOfWork,
        IDisposable
    {
        public BlogWebAppUnitOfWork(BlogDb db, IGenericRepository<Article> articles,
            IGenericRepository<Questionare> authors,
            IGenericRepository<Feedback> feedbacks,
            IGenericRepository<Tag> tags,
            IGenericRepository<ArticleAndTag> articlesAndTags, 
            IGenericRepository<User> users)
        {
            Db = db;
            Articles = articles;
            Authors = authors;
            Feedbacks = feedbacks;
            Tags = tags;
            ArticlesAndTags = articlesAndTags;
            Users = users;
        }

        private BlogDb Db { get; }

        public IGenericRepository<Article> Articles { get; }
        public IGenericRepository<Questionare> Authors { get; }
        public IGenericRepository<Feedback> Feedbacks { get; }
        public IGenericRepository<Tag> Tags { get; }
        public IGenericRepository<ArticleAndTag> ArticlesAndTags { get; }
        public IGenericRepository<User> Users { get; }

        public void Save()
        {
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}