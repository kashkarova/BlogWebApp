using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Interfaces;

namespace BlogWebApp.DAL.Repository.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BlogDb db) : base(db)
        {
        }

        public User GetById(string userId)
        {
            return Get(user => user.Id == userId);
        }

    }
}