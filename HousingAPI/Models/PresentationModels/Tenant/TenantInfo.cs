using HousingAPI.Models.PresentationModels.Contact;
using HousingAPI.Models.PresentationModels.Gender;
using HousingAPI.Models.PresentationModels.HousingUnit;
using HousingAPI.Models.PresentationModels.TenantCarRelationship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.PresentationModels.Tenant
{
    public class TenantInfo
    {
        public HousingUnitAddressMapper HousingUnit { get; set; }
        public ContactMapper Contact { get; set; }
        public GenderMapper Gender { get; set; }
        public TenantCarRelationshipMapper TenantCarRelationships { get; set; }
    }
}