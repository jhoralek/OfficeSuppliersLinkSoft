using Autofac;
using Autofac.Integration.Mvc;
using OfficeSuppliersLinkSoft.Data.Infrastructure;
using OfficeSuppliersLinkSoft.Data.Repositories;
using OfficeSuppliersLinkSoft.Service;
using OfficeSuppliersLinkSoft.Web.Mappings;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace OfficeSuppliersLinkSoft.Web.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            // Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }

        /// <summary>
        /// Used Autofac MVC 5 Integration for our repositories and services
        /// Dependency injection
        /// 
        /// This put all that layers toghether and its gonna work
        /// </summary>
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // !!! Beware of that the service constructors MUST BE public. 
            // When you implement from interface they are automaticaly protected
            // Autofac can not register classes with protected constructors from assembly
            // !!!

            // All repositories from assembly where GroupRepository is
            builder.RegisterAssemblyTypes(typeof(GroupRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // All services from assembly where GroupService is
            builder.RegisterAssemblyTypes(typeof(GroupService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}