﻿using HousingAPI.Models.PresentationModels.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.PresentationModels.MaintenanceRequest
{
    public class MaintenanceRequestTenantProviderMapper : MaintenanceRequestMapper
    {
        public TenantProviderMapper Tenant { get; set; }
    }
}