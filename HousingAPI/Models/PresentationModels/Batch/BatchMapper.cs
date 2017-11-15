using System;

namespace HousingAPI.Models.HousingModels
{
    public abstract class BatchMapper
    {
        public int BatchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }

        //public IList<TenantMapper> Tenants { get; set; }
    }
}