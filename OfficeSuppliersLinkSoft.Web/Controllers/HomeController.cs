using AutoMapper;
using OfficeSuppliersLinkSoft.Service;
using OfficeSuppliersLinkSoft.Web.Models;
using System.Web.Mvc;

namespace OfficeSuppliersLinkSoft.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly IGroupService _groupService;
        readonly ISupplierService _supplierService;

        /// <summary>
        /// Dependency injection of GroupService and SupplierService
        /// </summary>
        /// <param name="groupService">Instance of GroupService</param>
        /// <param name="supplierService">Instnace of SupplierService</param>
        public HomeController(IGroupService groupService, ISupplierService supplierService)
        {
            this._groupService = groupService;
            this._supplierService = supplierService;
        }

        /// <summary>
        /// Show all groups
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(Mapper.Map<GroupViewModel>(_groupService.GetGroups()));
        }
    }
}