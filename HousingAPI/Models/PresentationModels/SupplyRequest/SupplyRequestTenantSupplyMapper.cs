using HousingAPI.Models.PresentationModels.RequestSuppliesMap;
using HousingAPI.Models.PresentationModels.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.PresentationModels.SupplyRequest
{
    public class SupplyRequestTenantSupplyMapper : SupplyRequestMapper
    {
        public IEnumerable<RequestSuppliesMapMapper> RequestSuppliesMaps { get; set; }
        public TenantAddressMapper Tenant { get; set; }
    }
}