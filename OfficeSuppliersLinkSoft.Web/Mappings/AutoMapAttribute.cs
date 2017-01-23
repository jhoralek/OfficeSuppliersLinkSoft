using System;
using System.Web.Mvc;

namespace OfficeSuppliersLinkSoft.Web.Mappings
{
    /// <summary>
    /// Attribute for automaping controller's methods
    /// We can automap only GET methods
    /// 
    /// It is handling maping from domain to view model... Is pretty easy for unit testing
    /// and all anoying work with mapping every data request in our controllers
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AutoMapAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Means from where we are going to map
        /// </summary>
        private readonly Type _sourceType;
        /// <summary>
        /// Menas to where we are going to map
        /// </summary>
        private readonly Type _destType;

        public AutoMapAttribute(Type sourceType, Type destType)
        {
            _sourceType = sourceType;
            _destType = destType;
        }

        /// <summary>
        /// After controller function is execute, we are going to find our
        /// source and destination type
        /// 
        /// Call AutoMapFilter which is doing our mapping for us
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext) 
            => new AutoMapFilter(SourceType, DestType).OnActionExecuted(filterContext);

        /// <summary>
        /// Source type getter
        /// </summary>
        public Type SourceType => _sourceType;

        /// <summary>
        /// Destination type getter
        /// </summary>
        public Type DestType => _destType;
    }
}