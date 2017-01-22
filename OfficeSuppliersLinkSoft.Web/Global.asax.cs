using OfficeSuppliersLinkSoft.Data;
using OfficeSuppliersLinkSoft.Web.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OfficeSuppliersLinkSoft.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // initialize data
            System.Data.Entity.Database.SetInitializer(new OfficeSuppliersLinkSoftSeedData());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Autofac and Automapper configurations
            Bootstrapper.Run();
        }
    }
}
