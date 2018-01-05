using BlogWebApp.DAL.DbContext;
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
        }
    }
}