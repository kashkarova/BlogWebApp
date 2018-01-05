using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Interfaces;

namespace BlogWebApp.DAL.Repository.Implementation
{
    public class ArticleAndTagRepository : GenericRepository<ArticleAndTag>, IArticleAndTagRepository
    {
        public ArticleAndTagRepository(BlogDb db) : base(db)
        {
        }
    }
}