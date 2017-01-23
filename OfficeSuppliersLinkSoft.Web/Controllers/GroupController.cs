using AutoMapper;
using OfficeSuppliersLinkSoft.Model;
using OfficeSuppliersLinkSoft.Service;
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
        /// Initialize GrupController instance fo every request
        /// Dependency injection fo GroupService
        /// </summary>
        /// <param name="groupService">Instance of GroupService</param>
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        // GET: Group
        public ActionResult Index() => View(ListToViewModel(_groupService.GetGroups()));
        

        // GET: Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);            

            var groupViewModel = ToViewModel(_groupService.GetGroup(id.Value));
            if (groupViewModel == null)
                return HttpNotFound();

            return View(groupViewModel);
        }

        // GET: Group/Create
        public ActionResult Create() => View();        

        // POST: Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,Name")] GroupViewModel groupViewModel)
        {
            if (ModelState.IsValid)
            {
                _groupService.CreateGroup(ToDomain(groupViewModel));
                _groupService.SaveGroup();
               
                return RedirectToAction("Index");
            }

            return View(groupViewModel);
        }

        // GET: Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var groupViewModel = ToViewModel(_groupService.GetGroup(id.Value));
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
                _groupService.UpdateGroup(ToDomain(groupViewModel));
                _groupService.SaveGroup();
                
                return RedirectToAction("Index");
            }
            return View(groupViewModel);
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var groupViewModel = ToViewModel(_groupService.GetGroup(id.Value));
            if (groupViewModel == null)
                return HttpNotFound();

            return View(groupViewModel);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var groupViewModel = ToViewModel(_groupService.GetGroup(id));
            _groupService.RemoveGroup(ToDomain(groupViewModel));
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
        /// Self explanation method helps to map collection of Group to 
        /// GroupViewModel collection
        /// Reusable it shorts the code in controller
        /// </summary>
        /// <param name="list">list of Group</param>
        /// <returns>list of GroupViewModel</returns>
        IEnumerable<GroupViewModel> ListToViewModel(IEnumerable<Group> list) 
            => Mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(list);

        /// <summary>
        /// Maps Group object to GroupViewModel object
        /// </summary>
        /// <param name="g">Group object</param>
        /// <returns>GroupViewModel object</returns>
        GroupViewModel ToViewModel(Group g) => Mapper.Map<Group, GroupViewModel>(g);

        /// <summary>
        /// Maps GroupViewModel to GroupView
        /// </summary>
        /// <param name="gvm">GroupViewModel object</param>
        /// <returns>Group object</returns>
        Group ToDomain(GroupViewModel gvm) => Mapper.Map<GroupViewModel, Group>(gvm);
        
    }
}
