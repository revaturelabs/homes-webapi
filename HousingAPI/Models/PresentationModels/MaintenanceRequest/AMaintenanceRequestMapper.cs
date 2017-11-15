namespace HousingAPI.Models.HousingModels
{
    public abstract class AMaintenanceRequestMapper
    {
        public int MaintenanceRequestId { get; set; }
        public int TenantId { get; set; }
        public bool Active { get; set; }
        public string Message { get; set; }

        // public virtual TenantMapper Tenant { get; set; }
    }
}