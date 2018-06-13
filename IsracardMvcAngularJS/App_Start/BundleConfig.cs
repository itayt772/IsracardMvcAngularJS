using System.Web;
using System.Web.Optimization;

namespace IsracardMvcAngularJS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/AngularClient")
                        .Include("~/Scripts/angular.min.js")
                        .Include("~/Scripts/angular-route.min.js")
                        .Include("~/Scripts/angular-ui-router.min.js")
                        .Include("~/Scripts/ui-bootstrap-tpls.min.js")
                        .IncludeDirectory("~/AngularClient/Controllers", "*.js")
                        .IncludeDirectory("~/AngularClient/Services", "*.js")
                        .IncludeDirectory("~/AngularClient/Directives", "*.js")
                        .Include("~/AngularClient/AngularApp.js"));
        }
    }
}
