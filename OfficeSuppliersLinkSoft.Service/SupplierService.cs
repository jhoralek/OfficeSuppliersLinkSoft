﻿using OfficeSuppliersLinkSoft.Data.Infrastructure;
using OfficeSuppliersLinkSoft.Data.Repositories;
using OfficeSuppliersLinkSoft.Model;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace OfficeSuppliersLinkSoft.Service
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetSuppliers();
        IEnumerable<Supplier> GetSuppliers(Expression<Func<Supplier, bool>> where);
        Supplier GetSupplier(int supplierId);
        void CreateSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void RemoveSupplier(Supplier supplier);
        void SaveSupplier();
        void Dispose();
        void CreateOrUpdateSuppliersGroups(Supplier supplier, IEnumerable<Group> selectedGrups);
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
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
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
        /// Get the list of suppliers based on where expression
        /// </summary>
        /// <param name="where">expression</param>
        /// <returns>List of suppliers</returns>
        public IEnumerable<Supplier> GetSuppliers(Expression<Func<Supplier, bool>> where) => _supplierRepository.GetMany(where);        

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

        /// <summary>
        /// Dispose db context
        /// </summary>
        public void Dispose() => _unitOfWork.Dispose();

        /// <summary>
        /// Update suppliers group based on selection
        /// </summary>
        /// <param name="supplier">Current supplier</param>
        /// <param name="selectedGroups">selected groups</param>
        public void CreateOrUpdateSuppliersGroups(Supplier supplier, IEnumerable<Group> selectedGroups)
        {
            // manipulate with Supplier's groups
            supplier.Groups.ToList().ForEach(group => supplier.Groups.Remove(group));
            selectedGroups.ToList().ForEach(group => supplier.Groups.Add(group));

            // create or update supplier
            if (supplier.SupplierId <= 0)
                _supplierRepository.Add(supplier);            
            else
                _supplierRepository.Update(supplier);

        }
    }
}
