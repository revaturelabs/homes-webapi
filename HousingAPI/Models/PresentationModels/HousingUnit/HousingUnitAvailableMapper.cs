using HousingAPI.Models.PresentationModels.Address;
using HousingAPI.Models.PresentationModels.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.PresentationModels.HousingUnit
{
    public class HousingUnitAvailableMapper : HousingUnitMapper
    {
        public int Occupied { get; set; }
        public int Available { get; set; }

        public AddressMapper Address { get; set; }
        public IEnumerable<TenantBatchMapper> Tenants { get; set; }
    }
}