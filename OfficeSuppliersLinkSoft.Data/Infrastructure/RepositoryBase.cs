using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace OfficeSuppliersLinkSoft.Data.Infrastructure
{
    /// <summary>
    /// RepositoryBase is a base generic class for all new 
    /// specific repository classes which are coresponding with
    /// model class
    /// 
    /// Cover all available functions on data layer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> where T : class
    {
        /// <summary>
        /// Entities context
        /// </summary>
        OfficeSuppliersLinkSoftEntities _dataContext;

        /// <summary>
        /// Generic dbSet used for CRUD operations
        /// </summary>
        readonly IDbSet<T> _dbSet;       

        /// <summary>
        /// Factory provides initialization of DB context
        /// </summary>
        protected IDbFactory DbFactor { get; private set; }

        /// <summary>
        /// Instnace of DB context
        /// </summary>
        protected OfficeSuppliersLinkSoftEntities DbContext => _dataContext ?? (_dataContext = DbFactor.Init());

        /// <summary>
        /// Setup of repository instance with DB factory
        /// </summary>
        /// <param name="dbFactory">Initialize DB context</param>
        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactor = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        /// <summary>
        /// Mark as add new entity to the context
        /// </summary>
        /// <param name="entity">T entity</param>
        public virtual void Add(T entity) => _dbSet.Add(entity);

        /// <summary>
        /// Mark as update some entity in context
        /// </summary>
        /// <param name="entity">T entity</param>
        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Mark as remove some entity from context
        /// </summary>
        /// <param name="entity">T entity</param>
        public virtual void Delete(T entity) => _dataContext.Entry(entity).State = EntityState.Deleted;
        
        /// <summary>
        /// Mark as remove som entity or entities based on Linq expression
        /// </summary>
        /// <param name="where">Linq expression</param>
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var objects = _dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbSet.Remove(obj);
        }

        /// <summary>
        /// Get entity by its ID
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns>T entity by ID</returns>
        public virtual T GetById(int id) => _dbSet.Find(id);

        /// <summary>
        /// Get all entities of object
        /// </summary>
        /// <returns>List of entities</returns>
        public virtual IEnumerable<T> GetAll() => _dbSet.ToList();

        /// <summary>
        /// Get list of entities based on Where Expression query
        /// </summary>
        /// <param name="where">Where expression</param>
        /// <returns>List of T entities</returns>
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where) => _dbSet.Where(where).ToList();

        /// <summary>
        /// Get first entity based on Where expression
        /// </summary>
        /// <param name="where">Where expression</param>
        /// <returns>T entity or null</returns>
        public T Get(Expression<Func<T, bool>> where) => _dbSet.Where(where).FirstOrDefault<T>();
    }
}
