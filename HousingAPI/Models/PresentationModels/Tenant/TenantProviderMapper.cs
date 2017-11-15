using HousingAPI.Models.HousingModels;
using HousingAPI.Models.PresentationModels.HousingUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.PresentationModels.Tenant
{
    public class TenantProviderMapper : ATenantMapper
    {
        public HousingUnitProviderMapper HousingUnit { get; set; }
    }
}