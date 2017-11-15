using HousingAPI.Models.PresentationModels.Tenant;
using System.Collections.Generic;

namespace HousingAPI.Models.PresentationModels.Batch
{
    public class BatchTenantAddressMapper : ABatchMapper
    {
        public IEnumerable<TenantAddressMapper> Tenant { get; set; }
    }
}