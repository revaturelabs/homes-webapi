using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.HousingModels
{
    public class ContactMapper
    {
        public int batchId { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public string name { get; set; }
        
        //public IEnumerable<TenantMapper> Tenants { get; set; }
    }
}