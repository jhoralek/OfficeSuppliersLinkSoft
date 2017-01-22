using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OfficeSuppliersLinkSoft.Data.Infrastructure
{
    /// <summary>
    /// All CRUD operations did not sent direct command to the
    /// database. They only mark that entity.
    /// Service layer will be responsible for that commit action. It will be done
    /// by IUnitOfWork injected instance. [Pattern UnitOfWork]
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Add new entity to the context
        /// </summary>
        /// <param name="entity">T entity</param>
        void Add(T entity);

        /// <summary>
        /// Modify entity object
        /// </summary>
        /// <param name="entity">T entity</param>
        void Update(T entity);

        /// <summary>
        /// Remove entity object
        /// </summary>
        /// <param name="entity">T entity</param>
        void Delete(T entity);

        /// <summary>
        /// Remove entity object with func
        /// exxpression where
        /// </summary>
        /// <param name="where">Where linq expression</param>
        void Delete(Expression<Func<T, bool>> where);
        
        /// <summary>
        /// Get the entity by their ID
        /// </summary>
        /// <param name="id">Entity Id</param>
        /// <returns>T entity object</returns>
        T GetById(int id);

        /// <summary>
        /// Get the entity object use Expression
        /// </summary>
        /// <param name="where">Where linq expression</param>
        /// <returns>T entitys</returns>
        T Get(Expression<Func<T, bool>> where);

        /// <summary>
        /// Get all entities with type T
        /// </summary>
        /// <returns>List of all entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get list of entities use Expression 
        /// </summary>
        /// <param name="where">Where linq expression</param>
        /// <returns>List of entities</returns>
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
