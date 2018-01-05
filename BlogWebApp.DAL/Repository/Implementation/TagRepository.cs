using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Interfaces;

namespace BlogWebApp.DAL.Repository.Implementation
{
    public class TagRepository:GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(BlogDb db) : base(db)
        {
        }
    }
}