using System.Web.Optimization;

namespace OfficeSuppliersLinkSoft.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Content/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Content/jquery/jquery.validate*"));

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/Content/bootstrap/css/bootstrap.css",
                "~/Content/bootstrap/css/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                "~/Content/bootstrap/js/bootstrap.js", 
                "~/Content/bootstrap/js/site.js",
                "~/Content/bootstrap/js/respond.js"));


            BundleTable.EnableOptimizations = true;
        }
    }
}