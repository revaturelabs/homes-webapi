using HousingAPI.Models.HousingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.PresentationModels.Tenant
{
    public class TenantInfoMapper : ATenantMapper
    {
        public BatchMapper Batch { get; set; }
        public ContactMapper Contact { get; set; }
        public GenderMapper Gender { get; set; }
        public TenantCarRelationshipMapper TenantCarRelationships { get; set; }
    }
}