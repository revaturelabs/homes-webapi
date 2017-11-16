using HousingAPI.Models.PresentationModels.Address;
using HousingAPI.Models.PresentationModels.Tenant;
using System.Collections.Generic;

namespace HousingAPI.Models.PresentationModels.HousingUnit
{
    public class HousingUnitTenantInfoMapper : HousingUnitMapper
    {
        public AddressMapper Address { get; set; }
        public IEnumerable<TenantBatchMapper> Tenants { get; set; }
    }
}