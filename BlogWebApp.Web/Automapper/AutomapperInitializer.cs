using AutoMapper;
using BlogWebApp.BLL.Automapper;

namespace BlogWebApp.Web.Automapper
{
    public static class AutomapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<AutomapperEFToViewModel>(); });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}