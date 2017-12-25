using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Interfaces;

namespace BlogWebApp.DAL.Repository.Realizations
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository()
        {
        }

        public AuthorRepository(BlogDb db) : base(db)
        {
        }
    }
}