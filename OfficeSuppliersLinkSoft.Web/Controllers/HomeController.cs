using System.Web.Mvc;

namespace OfficeSuppliersLinkSoft.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Home view will be rendered
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() => View();        
    }
}
