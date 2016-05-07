using System.Web;
using System.Web.Optimization;

namespace iCheap.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/assets/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/assets/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/assets/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/assets/Scripts/bootstrap.js",
                        "~/assets/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/devextreme").Include(
                        "~/assets/Scripts/jquery.globalize/globalize.js",
                        "~/assets/Scripts/dx.webappjs.js"));

            bundles.Add(new ScriptBundle("~/bundles/utils").Include(
                        "~/assets/Scripts/utils/ui-jp.config.js",
                        "~/assets/Scripts/utils/ui-jp.js",
                        "~/assets/Scripts/utils/ui-load.js",
                        "~/assets/Scripts/utils/ui-nav.js",
                        "~/assets/Scripts/utils/ui-toggle.js",
                        "~/assets/Scripts/knockout-3.3.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/assets/Scripts/app/app.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/assets/bower_components/animate.css/animate.css",
                        "~/assets/bower_components/bootstrap/dist/css/bootstrap.css",
                        "~/assets/bower_components/font-awesome/css/font-awesome.css",
                        "~/assets/Content/font.css",
                        "~/assets/Content/app.css",
                        "~/assets/Content/themify-icons.css",
                        "~/assets/Content/dx.common.css",
                        "~/assets/Content/dx.light.css"));
        }
    }
}
