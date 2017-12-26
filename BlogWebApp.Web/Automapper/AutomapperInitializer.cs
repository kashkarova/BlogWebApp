using AutoMapper;
using BlogWebApp.BLL.Automapper;

namespace BlogWebApp.Web.Automapper
{
    public static class AutomapperInitializer
    {
        // Configuration customizing of comparized classes from AutomapperEFToViewModel() in BLL part 
        public static void Initialize()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<AutomapperEFToViewModel>(); });
            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}