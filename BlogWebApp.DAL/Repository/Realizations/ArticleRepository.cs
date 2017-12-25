using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;

namespace BlogWebApp.DAL.Repository.Realizations
{
    public class ArticleRepository : GenericRepository<Article>
    {
        public ArticleRepository()
        {
        }

        public ArticleRepository(BlogDb db) : base(db)
        {
        }
    }
}