using OfficeSuppliersLinkSoft.Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace OfficeSuppliersLinkSoft.Data
{
    public class OfficeSuppliersLinkSoftSeedData : DropCreateDatabaseIfModelChanges<OfficeSuppliersLinkSoftEntities>
    {
        /// <summary>
        /// Seed add date to the context
        /// </summary>
        /// <param name="context">DAL (data access layer) with our model</param>
        protected override void Seed(OfficeSuppliersLinkSoftEntities context)
        {
            GetGroups().ForEach(g => context.Groups.Add(g));
            GetSuppliers().ForEach(s => context.Suppliers.Add(s));
            GetSuppliersGroups().ForEach(sg => context.SuppliersGroups.Add(sg));

            context.Commit();
        }

        private static List<Group> GetGroups() => new List<Group>
        {
            new Group { GroupId = 1, Name = "Cleaners" },
            new Group { GroupId = 2, Name = "Office supply" },
            new Group { GroupId = 3, Name = "Telephone service" },
            new Group { GroupId = 4, Name = "Security" },
        };

        private static List<Supplier> GetSuppliers() =>  new List<Supplier>
        {
            new Supplier { SupplierId = 1, Name = "Akamai", Address = "State of the Internet Report, Cambridge, MA, USA", EmailAddress = "akamai@akamai.gov", Telephone = 123456789 },
            new Supplier { SupplierId = 2, Name = "GMI Ratings", Address = "New York, USA", EmailAddress = "gmi@gmirating.com", Telephone = 987654321 },
            new Supplier { SupplierId = 3, Name = "Thomson Reuters", Address = "London, UK", EmailAddress = "thomson@thomson.co.uk", Telephone = 147258369 },
            new Supplier { SupplierId = 4, Name = "Office Depot", Address = "Raton, Florida, USA", EmailAddress = "officedepot@officedepot.com", Telephone = 369852147 },
            new Supplier { SupplierId = 5, Name = "Stanley Bostitch", Address = "East Greenwitch, Rhode Island, USA", EmailAddress = "bostitch@bostitch.com", Telephone = 789654123 },
            new Supplier { SupplierId = 6, Name = "Arzum Dis Ticaret A.S.", Address = "Abdi Ipekci CAD. No. 165 Bayrampasa", EmailAddress = "arzum@arzum.tr", Telephone = 120945609 },
            new Supplier { SupplierId = 7, Name = "EasyHomeLife", Address = "McKechnie Ave West Vancouver BC V7V 2M5 Canada", EmailAddress = "easyhomelife@eashyhomelife.ca", Telephone = 162925807 },
            new Supplier { SupplierId = 8, Name = "Carvalho's Cleaning", Address = "Egypt", EmailAddress = "carvalhocelaning@carvalhocleaning.com", Telephone = 204906005 },
            new Supplier { SupplierId = 9, Name = "Spaceon (HK) Development Co., Ltd", Address = "Rm2, 18 / F Carnival Comm Bldg. , 18, Java Road, North Point", EmailAddress = "spaceon@spaceon.hk", Telephone = 258741369 },
        };

        private static List<SuppliersGroup> GetSuppliersGroups() => new List<SuppliersGroup>
        {
            new SuppliersGroup { SuppliersGroupId = 1, GroupId = 1, SupplierId = 9 },
            new SuppliersGroup { SuppliersGroupId = 2, GroupId = 1, SupplierId = 8 },
            new SuppliersGroup { SuppliersGroupId = 3, GroupId = 3, SupplierId = 7 },
            new SuppliersGroup { SuppliersGroupId = 4, GroupId = 3, SupplierId = 6 },
            new SuppliersGroup { SuppliersGroupId = 5, GroupId = 2 , SupplierId = 5 },
            new SuppliersGroup { SuppliersGroupId = 6, GroupId = 2 , SupplierId = 4 },
            new SuppliersGroup { SuppliersGroupId = 7, GroupId = 4 , SupplierId = 3 },
            new SuppliersGroup { SuppliersGroupId = 8, GroupId = 4 , SupplierId = 2 },
            new SuppliersGroup { SuppliersGroupId = 9, GroupId = 2 , SupplierId = 1 },
        };
    }
}
