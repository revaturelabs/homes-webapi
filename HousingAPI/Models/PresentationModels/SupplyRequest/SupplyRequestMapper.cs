using HousingAPI.Models.PresentationModels.RequestSuppliesMap;
using HousingAPI.Models.PresentationModels.Tenant;
using System.Collections.Generic;

namespace HousingAPI.Models.PresentationModels.SupplyRequest
{
    public class SupplyRequestMapper
    {
        public int SupplyRequestId { get; set; }
        public int TenantId { get; set; }
        public bool Active { get; set; }
    }
}