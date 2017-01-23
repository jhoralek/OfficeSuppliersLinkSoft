using AutoMapper;
using OfficeSuppliersLinkSoft.Model;
using OfficeSuppliersLinkSoft.Service;
using OfficeSuppliersLinkSoft.Web.Mappings;
using OfficeSuppliersLinkSoft.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace OfficeSuppliersLinkSoft.Web.Controllers
{
    /// <summary>
    /// This controller has been scaffolded by Visual Studio.
    /// 
    /// There should be some changes in code due to the basic
    /// scaffolding functionality.
    /// It can be modified for example by T4 template which will be
    /// used for own custom data context based on Repository pattern
    /// </summary>
    public class GroupController : Controller
    {
        /// <summary>
        /// Interface to the groupService
        /// Is initialized throught DI in GroupController constructor
        /// </summary>
        readonly IGroupService _groupService;

        /// <summary>
        /// Interface to the supplierService
        /// </summary>
        readonly ISupplierService _supplierService;

        /// <summary>
        /// Initialize GrupController instance fo every request
        /// Dependency injection fo GroupService
        /// </summary>
        /// <param name="groupService">Instance of GroupService</param>
        public GroupController(IGroupService groupService, ISupplierService supplierService)
        {
            _groupService = groupService;
            _supplierService = supplierService;
        }

        // GET: Group
        [AutoMap(typeof(IEnumerable<Group>), typeof(IEnumerable<GroupViewModel>))]
        public ActionResult Index() => View(_groupService.GetGroups());
        
        // GET: Group/Details/5
        [AutoMap(typeof(Group), typeof(GroupViewModel))]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);            

            var groupViewModel = _groupService.GetGroup(id.Value);
            if (groupViewModel == null)
                return HttpNotFound();

            return View(groupViewModel);
        }

        // GET: Group/Create
        public ActionResult Create()
        {
            // we need to push list of suppliers to the view
            // there will be process to select what supplies belongs
            // to new group


            return View();
        }

        // POST: Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AutoMap(typeof(GroupViewModel), typeof(Group))]
        public ActionResult Create([Bind(Include = "GroupId,Name")] GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid)
            {
                _groupService.CreateGroup(GroupToDomain(groupViewModel));
                _groupService.SaveGroup();
               
                return RedirectToAction("Index");
            }

            return View(groupViewModel);
        }

        // GET: Group/Edit/5
        [AutoMap(typeof(Group), typeof(GroupViewModel))]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var groupViewModel = _groupService.GetGroup(id.Value);
            if (groupViewModel == null)
                return HttpNotFound();

            return View(groupViewModel);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,Name")] GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid)
            {
                _groupService.UpdateGroup(GroupToDomain(groupViewModel));
                _groupService.SaveGroup();
                
                return RedirectToAction("Index");
            }
            return View(groupViewModel);
        }

        // GET: Group/Delete/5
        [AutoMap(typeof(Group), typeof(GroupViewModel))]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var groupViewModel = _groupService.GetGroup(id.Value);
            if (groupViewModel == null)
                return HttpNotFound();

            return View(groupViewModel);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "GroupId")] GroupViewModel groupViewModel)
        {
            _groupService.RemoveGroup(GroupToDomain(groupViewModel));
            _groupService.SaveGroup();
            
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Register group service disposing
        /// </summary>
        /// <param name="disposing">it is time to dispose true/false</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _groupService.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Maps GroupViewModel to GroupView
        /// </summary>
        /// <param name="gvm">GroupViewModel object</param>
        /// <returns>Group object</returns>
        Group GroupToDomain(GroupViewModel gvm) => Mapper.Map<GroupViewModel, Group>(gvm);        
    }
}
