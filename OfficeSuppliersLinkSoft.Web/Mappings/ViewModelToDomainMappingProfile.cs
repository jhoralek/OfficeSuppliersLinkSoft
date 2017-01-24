using AutoMapper;
using OfficeSuppliersLinkSoft.Model;
using OfficeSuppliersLinkSoft.Web.Models;

namespace OfficeSuppliersLinkSoft.Web.Mappings
{
    /// <summary>
    /// Mapping profile from View model to Domain service
    /// </summary>
    public class ViewModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// Overridenname of profile
        /// </summary>
        public override string ProfileName => "ViewModelToDomainMappings";

        /// <summary>
        /// Configure our view model class to domain classes
        /// </summary>
        protected override void Configure()
        {
            Mapper.CreateMap<GroupViewModel, Group>();
            Mapper.CreateMap<SupplierViewModel, Supplier>();
            Mapper.CreateMap<AssignedGroupsViewModel, Group>();
        }
    }
}