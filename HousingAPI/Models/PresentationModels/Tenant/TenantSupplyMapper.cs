using HousingAPI.Models.PresentationModels.SupplyRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.PresentationModels.Tenant
{
    public class TenantSupplyMapper : TenantMapper
    {
        public IEnumerable<SupplyRequestMapper> SupplyRequests { get; set; }
    }
}