using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;

namespace BlogWebApp.DAL.Repository.Realizations
{
    public class AuthorRepository : GenericRepository<Author>
    {
        public AuthorRepository()
        {
        }

        public AuthorRepository(BlogDb db) : base(db)
        {
        }
    }
}