using AutoMapper;
using OfficeSuppliersLinkSoft.Model;
using OfficeSuppliersLinkSoft.Web.Models;

namespace OfficeSuppliersLinkSoft.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Configure mapping from Domain to ViewModel and back
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(x => x.CreateMap<Group, GroupViewModel>());
            Mapper.Initialize(x => x.CreateMap<Supplier, SupplierViewModel>());
        }
    }
}