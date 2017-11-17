using HousingAPI.Models.PresentationModels.Address;
using HousingAPI.Models.PresentationModels.Provider;
using HousingAPI.Models.PresentationModels.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.PresentationModels.HousingUnit
{
    public class HousingUnitProviderTenantSupplyMapper : HousingUnitMapper
    {
        public AddressMapper Address { get; set; }
        public IEnumerable<TenantSupplyMapper> Tenants { set; get; }
    }
}