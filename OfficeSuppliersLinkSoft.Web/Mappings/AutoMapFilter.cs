using AutoMapper;
using System;
using System.Web.Mvc;

namespace OfficeSuppliersLinkSoft.Web.Mappings
{
    /// <summary>
    /// Base action filter is class defined 
    /// on which events we are going to execute our auto map procedure
    /// 
    /// </summary>
    public abstract class BaseActionFilter : IActionFilter, IResultFilter
    {
        /// <summary>
        /// Do the job while the action is executing
        /// </summary>
        /// <param name="filterContext">filter param contains ViewData.Model</param>
        public virtual void OnActionExecuting(ActionExecutingContext filterContext) {}

        /// <summary>
        /// Do the job after the action is executed
        /// </summary>
        /// <param name="filterContext">filter param contains ViewData.Model</param>
        public virtual void OnActionExecuted(ActionExecutedContext filterContext) {}

        /// <summary>
        /// Do the job when the result is executing
        /// </summary>
        /// <param name="filterContext">filter param contains ViewData.Model</param>
        public virtual void OnResultExecuting(ResultExecutingContext filterContext) {}

        /// <summary>
        /// Do the job after the result is executed
        /// </summary>
        /// <param name="filterContext">filter param contains ViewData.Model</param>
        public virtual void OnResultExecuted(ResultExecutedContext filterContext) {}
    }

    /// <summary>
    /// Class implementing mapping of our controller's functions
    /// </summary>
    public class AutoMapFilter : BaseActionFilter
    {
        private readonly Type _sourceType;
        private readonly Type _destType;

        /// <summary>
        /// Initialize instance of AutoMap
        /// </summary>
        /// <param name="sourceType">source type</param>
        /// <param name="destType">destination type</param>
        public AutoMapFilter(Type sourceType, Type destType)
        {
            _sourceType = sourceType;
            _destType = destType;
        }

        /// <summary>
        /// Do the mapping job after the action is executed
        /// </summary>
        /// <param name="filterContext">filter param contains our model</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext) =>
            filterContext.Controller.ViewData.Model = Mapper.Map(filterContext.Controller.ViewData.Model, _sourceType, _destType);
    }
}