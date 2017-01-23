using AutoMapper;

namespace OfficeSuppliersLinkSoft.Web.Mappings
{
    /// <summary>
    /// Auto mapping from domain to view and vise versa
    /// </summary>
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Configure mapping from Domain to ViewModel and back
        /// </summary>
        public static void Configure()
        {
            // It is possible to create as many profiles you want to
            Mapper.Initialize(x => 
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}