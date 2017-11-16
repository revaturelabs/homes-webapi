using System;

namespace HousingAPI.Models.PresentationModels.Tenant
{
    public class ATenantMapper
    {
        public int TenantId { get; set; }
        public int ContactId { get; set; }
        public int BatchId { get; set; }
        public int HousingUnitId { get; set; }
        public int GenderId { get; set; }
        public DateTime MoveInDate { get; set; }
        public bool HasMoved { get; set; }
        public bool HasKey { get; set; }
    }
}