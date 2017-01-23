using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using OfficeSuppliersLinkSoft.Web.Models;
using OfficeSuppliersLinkSoft.Service;
using OfficeSuppliersLinkSoft.Model;
using AutoMapper;
using OfficeSuppliersLinkSoft.Web.Mappings;

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
    public class SupplierController : Controller
    {
        /// <summary>
        /// Interface to the supplierService
        /// Is initialized throught DI in SupplierController constructor
        /// </summary>
        readonly ISupplierService _supplierService;

        /// <summary>
        /// Initialize SupplierController instance fo every request
        /// Dependency injection fo SupplierService
        /// </summary>
        /// <param name="supplierService">Instance of SupplierService</param>
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: Supplier
        [AutoMap(typeof(IEnumerable<Supplier>), typeof(IEnumerable<SupplierViewModel>))]
        public ActionResult Index() => View(_supplierService.GetSuppliers());

        // GET: Supplier/Details/5
        [AutoMap(typeof(Supplier), typeof(SupplierViewModel))]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var supplierViewModel = _supplierService.GetSupplier(id.Value);
            if (supplierViewModel == null)
                return HttpNotFound();
                        
            return View(supplierViewModel);
        }

        // GET: Supplier/Create
        public ActionResult Create() => View();

        // POST: Supplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierId,Name,Address,EmailAddress,Telephone")] SupplierViewModel supplierViewModel)
        {
            if (ModelState.IsValid)
            {
                _supplierService.CreateSupplier(ToDomain(supplierViewModel));
                _supplierService.SaveSupplier();

                return RedirectToAction("Index");
            }

            return View(supplierViewModel);
        }

        // GET: Supplier/Edit/5
        [AutoMap(typeof(Supplier), typeof(SupplierViewModel))]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var supplierViewModel = _supplierService.GetSupplier(id.Value);
            if (supplierViewModel == null)
                return HttpNotFound();

            return View(supplierViewModel);
        }

        // POST: Supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierId,Name,Address,EmailAddress,Telephone")] SupplierViewModel supplierViewModel)
        {
            if (ModelState.IsValid)
            {
                _supplierService.UpdateSupplier(ToDomain(supplierViewModel));
                _supplierService.SaveSupplier();

                return RedirectToAction("Index");
            }
            return View(supplierViewModel);
        }

        // GET: Supplier/Delete/5
        [AutoMap(typeof(Supplier), typeof(SupplierViewModel))]
        public ActionResult Delete(int? id)
        {
            if (id == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var supplierViewModel = _supplierService.GetSupplier(id.Value);
            if (supplierViewModel == null)            
                return HttpNotFound();
            
            return View(supplierViewModel);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "SupplierId")] SupplierViewModel supplierViewModel)
        {
            _supplierService.RemoveSupplier(ToDomain(supplierViewModel));
            _supplierService.SaveSupplier();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Register supplier service disposing
        /// </summary>
        /// <param name="disposing">it is time to dispose true/false</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _supplierService.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Maps SupplierViewModel to SupplierView
        /// </summary>
        /// <param name="gvm">SupplierViewModel object</param>
        /// <returns>Supplier object</returns>
        Supplier ToDomain(SupplierViewModel gvm) => Mapper.Map<SupplierViewModel, Supplier>(gvm);
    }
}
