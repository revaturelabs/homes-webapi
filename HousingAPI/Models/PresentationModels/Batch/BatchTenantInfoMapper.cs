using HousingAPI.Models.PresentationModels.Tenant;
using System.Collections.Generic;

namespace HousingAPI.Models.PresentationModels.Batch
{
    public class BatchTenantInfoMapper : ABatchMapper
    {
        public IEnumerable<TenantInfoMapper> Tenants { get; set; }
    }
}