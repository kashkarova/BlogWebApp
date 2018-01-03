using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Interfaces;

namespace BlogWebApp.DAL.UoW.Interface
{
    public interface IBlogWebAppUnitOfWork
    {
        IGenericRepository<Article> Articles { get; }
        IGenericRepository<Author> Authors { get; }
        IGenericRepository<AuthorAndArticle> AuthorsAndArticles { get; }
        IGenericRepository<Feedback> Feedbacks { get; }

        void Save();
    }
}