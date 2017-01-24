using AutoMapper;
using OfficeSuppliersLinkSoft.Model;
using OfficeSuppliersLinkSoft.Web.Models;

namespace OfficeSuppliersLinkSoft.Web.Mappings
{
    /// <summary>
    /// Mapping profile from Domain service to View model
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// Overridenname of profile
        /// </summary>
        public override string ProfileName => "DomainToViewModelMappings";

        /// <summary>
        /// Configure our model classes to view model classes
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<Group, GroupViewModel>();
            Mapper.CreateMap<Supplier, SupplierViewModel>();
            Mapper.CreateMap<Group, AssignedGroupsViewModel>();
        }
    }
}