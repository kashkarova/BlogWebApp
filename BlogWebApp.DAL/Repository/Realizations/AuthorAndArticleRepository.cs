using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;

namespace BlogWebApp.DAL.Repository.Realizations
{
    public class AuthorAndArticleRepository : GenericRepository<AuthorAndArticle>
    {
        public AuthorAndArticleRepository()
        {
        }

        public AuthorAndArticleRepository(BlogDb db) : base(db)
        {
        }
    }
}