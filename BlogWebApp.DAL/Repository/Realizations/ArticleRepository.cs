using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Interfaces;

namespace BlogWebApp.DAL.Repository.Realizations
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
    }
}