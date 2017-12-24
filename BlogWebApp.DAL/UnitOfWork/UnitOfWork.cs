using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Interfaces;
using BlogWebApp.DAL.Repository.Realizations;

namespace BlogWebApp.DAL.UnitOfWork
{
    public class UnitOfWork
    {
        public UnitOfWork()
        {
            AuthorRepository = new GenericRepository<Author>();
            ArticleRepository = new GenericRepository<Article>();
            FeedbackRepository = new GenericRepository<Feedback>();
            AuthorAndArticleRepository = new GenericRepository<AuthorAndArticle>();
        }

        public IGenericRepository<Author> AuthorRepository { get; }
        public IGenericRepository<Article> ArticleRepository { get; }
        public IGenericRepository<Feedback> FeedbackRepository { get; }
        public IGenericRepository<AuthorAndArticle> AuthorAndArticleRepository { get; }
    }
}