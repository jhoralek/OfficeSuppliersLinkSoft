using AutoMapper;
using OfficeSuppliersLinkSoft.Model;
using OfficeSuppliersLinkSoft.Service;
using OfficeSuppliersLinkSoft.Web.Models;
using System.Collections.Generic;
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
            _groupService = groupService;
            _supplierService = supplierService;
        }

        /// <summary>
        /// Show all groups
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() => View(Mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(_groupService.GetGroups()));        
    }
}