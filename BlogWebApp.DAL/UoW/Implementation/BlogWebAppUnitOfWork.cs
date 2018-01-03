﻿using System;
using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Implementation;
using BlogWebApp.DAL.Repository.Interfaces;
using BlogWebApp.DAL.UoW.Interface;

namespace BlogWebApp.DAL.UoW.Implementation
{
    public class BlogWebAppUnitOfWork : IBlogWebAppUnitOfWork, IDisposable
    {
        private readonly BlogDb _db;

        public IGenericRepository<Article> Articles { get; }
        public IGenericRepository<Author> Authors { get; }
        public IGenericRepository<AuthorAndArticle> AuthorsAndArticles { get; }
        public IGenericRepository<Feedback> Feedbacks { get; }

        public BlogWebAppUnitOfWork()
        {
            Articles = new GenericRepository<Article>(_db);
            Authors = new GenericRepository<Author>(_db);
            AuthorsAndArticles = new GenericRepository<AuthorAndArticle>(_db);
            Feedbacks = new GenericRepository<Feedback>(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}