using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Interfaces;

namespace BlogWebApp.DAL.Repository.Implementation
{
    public class QuestionareRepository :
        GenericRepository<Questionare>,
        IQuestionareRepository
    {
        public QuestionareRepository(BlogDb db) : base(db)
        {
        }
    }
}