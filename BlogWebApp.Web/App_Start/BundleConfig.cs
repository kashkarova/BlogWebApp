using System.Web.Optimization;

namespace BlogWebApp.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/StandartScripts/jquery-{version}.js",
                "~/Scripts/StandartScripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/StandartScripts/jquery.validate.js",
                "~/Scripts/StandartScripts/jquery.validate.unobtrusive.js"));


            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/MyScripts/Script.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/StandartScripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/Site.css"));
        }
    }
}