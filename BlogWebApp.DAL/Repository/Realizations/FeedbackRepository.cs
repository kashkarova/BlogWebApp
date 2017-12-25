using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;

namespace BlogWebApp.DAL.Repository.Realizations
{
    public class FeedbackRepository : GenericRepository<Feedback>
    {
        public FeedbackRepository()
        {
        }

        public FeedbackRepository(BlogDb db) : base(db)
        {
        }
    }
}