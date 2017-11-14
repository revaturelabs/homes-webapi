using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.HousingModels
{
    public class BatchMapper
    {
        public int BatchId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Eame { get; set; }
        
        //public IList<TenantMapper> Tenants { get; set; }
    }
}