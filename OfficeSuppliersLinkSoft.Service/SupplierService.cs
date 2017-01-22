using OfficeSuppliersLinkSoft.Data.Infrastructure;
using OfficeSuppliersLinkSoft.Data.Repositories;
using OfficeSuppliersLinkSoft.Model;
using System.Collections.Generic;

namespace OfficeSuppliersLinkSoft.Service
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetSuppliers();
        Supplier GetSupplier(int SupplierId);
        void CreateSupplier(Supplier Supplier);
        void UpdateSupplier(Supplier Supplier);
        void RemoveSupplier(Supplier Supplier);
        void SaveSupplier();
    }

    /// <summary>
    /// Service of SupplierService
    /// This is the only layer where business logic
    /// should be. This service will be interacting with
    /// Controllers in presentation layer.
    /// 
    /// We use ISupplierService interface as a guide for all
    /// neccessary functions
    /// </summary>
    public class SupplierService : ISupplierService
    {
        /// <summary>
        /// We use this interface for access to the Supplier's repo.
        /// </summary>
        ISupplierRepository _supplierRepository;

        /// <summary>
        /// Execute DB commands
        /// </summary>
        IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initialize new instance of Supplier service with neccessary repositories injected into this object
        /// </summary>
        /// <param name="supplierRepository">Supplier's repository</param>
        /// <param name="unitOfWork">Unit of work instance for data command execution</param>
        public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
        {
            this._supplierRepository = supplierRepository;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Create new supplier
        /// </summary>
        /// <param name="supplier">Supplier object</param>
        public void CreateSupplier(Supplier supplier) => _supplierRepository.Add(supplier);

        /// <summary>
        /// Get the suppplier by its ID
        /// </summary>
        /// <param name="supplierId">Supplier's ID</param>
        /// <returns></returns>
        public Supplier GetSupplier(int supplierId) => _supplierRepository.GetById(supplierId);

        /// <summary>
        /// Method otains every supplier in repository
        /// </summary>
        /// <returns>List of suppliers</returns>
        public IEnumerable<Supplier> GetSuppliers() => _supplierRepository.GetAll();

        /// <summary>
        /// Mark supplier as remove
        /// </summary>
        /// <param name="supplier">Instance of supplier object</param>
        public void RemoveSupplier(Supplier supplier) => _supplierRepository.Delete(supplier);

        /// <summary>
        /// Mark supplier as updated
        /// </summary>
        /// <param name="supplier">Instance of supplier object</param>
        public void UpdateSupplier(Supplier supplier) => _supplierRepository.Update(supplier);

        /// <summary>
        /// Execute all commands witch has been done befor 
        /// call this method
        /// </summary>
        public void SaveSupplier() => _unitOfWork.Commit();
    }
}
