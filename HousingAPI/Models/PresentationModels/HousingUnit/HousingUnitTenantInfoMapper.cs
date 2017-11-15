using HousingAPI.Models.HousingModels;
using HousingAPI.Models.PresentationModels.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.PresentationModels.HousingUnit
{
    public class HousingUnitTenantInfoMapper : AHousingUnitMapper
    {
        public AddressMapper Address { get; set; }
        public IEnumerable<TenantInfoMapper> Tenants { get; set; }
    }
}