using System.Web;
using System.Web.Optimization;

namespace iCheap.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/admin/bundles/jquery").Include(
                        "~/assets/admin/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/jqueryval").Include(
                        "~/assets/admin/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/admin/bundles/modernizr").Include(
                        "~/assets/admin/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/admin/bundles/bootstrap").Include(
                        "~/assets/admin/Scripts/bootstrap.js",
                        "~/assets/admin/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/devextreme").Include(
                        "~/assets/admin/Scripts/jquery.globalize/globalize.js",
                        "~/assets/admin/Scripts/dx.webappjs.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/utils").Include(
                        "~/assets/admin/Scripts/utils/ui-jp.config.js",
                        "~/assets/admin/Scripts/utils/ui-jp.js",
                        "~/assets/admin/Scripts/utils/ui-load.js",
                        "~/assets/admin/Scripts/utils/ui-nav.js",
                        "~/assets/admin/Scripts/utils/ui-toggle.js",
                        "~/assets/admin/Scripts/knockout-3.3.0.js"));

            bundles.Add(new ScriptBundle("~/admin/bundles/app").Include(
                        "~/assets/admin/Scripts/app/app.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/admin/Content/css").Include(
                        "~/assets/admin/bower_components/animate.css/animate.css",
                        "~/assets/admin/bower_components/bootstrap/dist/css/bootstrap.css",
                        "~/assets/admin/bower_components/font-awesome/css/font-awesome.css",
                        "~/assets/admin/Content/font.css",
                        "~/assets/admin/Content/app.css",
                        "~/assets/admin/Content/themify-icons.css",
                        "~/assets/admin/Content/dx.common.css",
                        "~/assets/admin/Content/dx.light.css"));
        }
    }
}
