using HousingAPI.Models.PresentationModels.Tenant;
using System.Collections.Generic;

namespace HousingAPI.Models.HousingModels
{
    public abstract class ASupplyRequestMapper
    {
        public int SupplyRequestId { get; set; }
        public int TenantId { get; set; }
        public bool Active { get; set; }

        public  IEnumerable<RequestSuppliesMapMapper> RequestSuppliesMaps { get; set; }
        public TenantAddressMapper Tenant { get; set; }
    }
}