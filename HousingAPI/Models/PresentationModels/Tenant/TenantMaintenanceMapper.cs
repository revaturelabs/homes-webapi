using HousingAPI.Models.PresentationModels.MaintenanceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.PresentationModels.Tenant
{
    public class TenantMaintenanceMapper : TenantMapper
    {
        public IEnumerable<MaintenanceRequestMapper> MaintenanceRequests { get; set; }
    }
}