using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Interfaces;

namespace BlogWebApp.DAL.UoW.Interface
{
    public interface IBlogWebAppUnitOfWork
    {
        IGenericRepository<Article> Articles { get; }
        IGenericRepository<Questionare> Authors { get; }
        IGenericRepository<Feedback> Feedbacks { get; }
        IGenericRepository<Tag> Tags { get; }
        IGenericRepository<ArticleAndTag> ArticlesAndTags { get; }
        IGenericRepository<User> Users { get; }

        void Save();
    }
}