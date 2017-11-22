using HousingAPI.Models.PresentationModels.Contact;
using HousingAPI.Models.PresentationModels.HousingUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.PresentationModels.Tenant
{
    public class TenantRequestMapper : TenantMapper
    {
        public HousingUnitAddressMapper HousingUnit { get; set; }
        public ContactMapper Contact { get; set; }
    }
}