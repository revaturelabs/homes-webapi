using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HousingAPI.Models.HousingModels;
using HousingAPI.Models.PresentationModels.Tenant;

namespace HousingAPI.Models.PresentationModels.Batch
{
    public class BatchTenantAddressMapper : ABatchMapper
    {
        public IEnumerable<TenantAddressMapper> Tenant { get; set; }
    }
}