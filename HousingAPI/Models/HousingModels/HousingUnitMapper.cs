using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.HousingModels
{
    public class HousingUnitMapper
    {
        public int housingUnitId { get; set; }
        public Nullable<int> providerId { get; set; }
        public Nullable<int> addressId { get; set; }
        public string housingSignature { get; set; }
        public int capacity { get; set; }

        //public Address Address { get; set; }
        //public Provider Provider { get; set; }
        //public ICollection<Tenant> Tenants { get; set; }
    }
}