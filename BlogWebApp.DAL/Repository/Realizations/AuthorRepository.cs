using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Interfaces;

namespace BlogWebApp.DAL.Repository.Realizations
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
    }
}