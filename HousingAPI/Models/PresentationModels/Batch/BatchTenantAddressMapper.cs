using HousingAPI.Models.PresentationModels.Tenant;
using System.Collections.Generic;

namespace HousingAPI.Models.PresentationModels.Batch
{
    public class BatchTenantAddressMapper : BatchMapper
    {
        public IEnumerable<TenantAddressMapper> Tenant { get; set; }
    }
}