using HousingAPI.Models.PresentationModels.Tenant;
using System.Collections.Generic;

namespace HousingAPI.Models.PresentationModels.Batch
{
    public class BatchTenantMapper : BatchMapper
    {
        public IEnumerable<TenantAddressMapper> Tenant { get; set; }
    }
}