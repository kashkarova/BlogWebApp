using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Interfaces;

namespace BlogWebApp.DAL.Repository.Realizations
{
    public class AuthorAndArticleRepository : GenericRepository<AuthorAndArticle>, IAuthorAndArticleRepository
    {
        public AuthorAndArticleRepository()
        {
        }

        public AuthorAndArticleRepository(BlogDb db) : base(db)
        {
        }
    }
}