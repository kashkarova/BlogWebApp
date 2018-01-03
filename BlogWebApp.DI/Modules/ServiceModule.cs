using BlogWebApp.BLL.Services.Implementations;
using BlogWebApp.BLL.Services.Interfaces;
using Ninject.Modules;

namespace BlogWebApp.DI.Modules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IArticleService>().To<ArticleService>();
            Bind<IAuthorService>().To<AuthorService>();
            Bind<IFeedbackService>().To<FeedbackService>();
        }
    }
}