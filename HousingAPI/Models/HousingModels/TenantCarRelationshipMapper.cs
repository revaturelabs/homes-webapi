using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.HousingModels
{
    public class TenantCarRelationshipMapper
    {
        public int RelationshipId { get; set; }
        public int TenantId { get; set; }
        public bool ParkingPassStatus { get; set; }

        //public virtual Tenant Tenant { get; set; }
    }

}