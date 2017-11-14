using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.HousingModels
{
    public class SupplyRequestMapper
    {
        public int SupplyRequestId { get; set; }
        public int TenantId { get; set; }
        public bool Active { get; set; }

        //public virtual ICollection<RequestSuppliesMap> RequestSuppliesMaps { get; set; }
        //public virtual Tenant Tenant { get; set; }
    }
}