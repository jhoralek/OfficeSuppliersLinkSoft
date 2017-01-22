using System.Web.Optimization;

namespace OfficeSuppliersLinkSoft.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js")
                .Include("~/Content/bootstrap/js/bootstrap.js", 
                         "~/Content/bootstrap/js/site.js"));

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css")
                .Include("~/Content/bootstrap/css/bootstrap.css", 
                         "~/Content/bootstrap/css/site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}