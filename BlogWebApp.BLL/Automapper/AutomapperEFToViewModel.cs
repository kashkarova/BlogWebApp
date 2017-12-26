using AutoMapper;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.ViewModel;

namespace BlogWebApp.BLL.Automapper
{
    public class AutomapperEFToViewModel : Profile
    {
        // Comparison of classes from TEntity to TEntityViewModel and inversely
        public AutomapperEFToViewModel()
        {
            CreateMap<Author, AuthorViewModel>().ReverseMap();
            CreateMap<Article, ArticleViewModel>().ReverseMap();
            CreateMap<Feedback, FeedbackViewModel>().ReverseMap();
            CreateMap<AuthorAndArticle, AuthorAndArticleViewModel>().ReverseMap();
        }
    }
}