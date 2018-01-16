using BlogWebApp.DAL.DbContext;
using BlogWebApp.DAL.DbEntities;
using BlogWebApp.DAL.Repository.Implementation;
using BlogWebApp.DAL.Repository.Interfaces;
using BlogWebApp.DAL.UoW.Implementation;
using BlogWebApp.DAL.UoW.Interface;
using Ninject.Modules;

namespace BlogWebApp.DI.Modules
{
    public class DALModule : NinjectModule
    {
        public override void Load()
        {
            Bind<BlogDb>().ToSelf();

            Bind<IBlogWebAppUnitOfWork>().To<BlogWebAppUnitOfWork>();

            Bind<IGenericRepository<Article>>().To<GenericRepository<Article>>();
            Bind<IGenericRepository<ArticleAndTag>>().To<GenericRepository<ArticleAndTag>>();
            Bind<IGenericRepository<Questionare>>().To<GenericRepository<Questionare>>();
            Bind<IGenericRepository<Feedback>>().To<GenericRepository<Feedback>>();
            Bind<IGenericRepository<Tag>>().To<GenericRepository<Tag>>();
            Bind<IGenericRepository<User>>().To<GenericRepository<User>>();
        }
    }
}