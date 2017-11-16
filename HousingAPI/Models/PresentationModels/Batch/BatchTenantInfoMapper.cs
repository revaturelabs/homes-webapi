using HousingAPI.Models.PresentationModels.Tenant;
using System.Collections.Generic;

namespace HousingAPI.Models.PresentationModels.Batch
{
    public class BatchTenantInfoMapper : BatchMapper
    {
        public IEnumerable<TenantBatchMapper> Tenants { get; set; }
    }
}