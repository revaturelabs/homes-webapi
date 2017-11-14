namespace HousingAPI.Models.HousingModels
{
    public class MaintenanceRequestMapper
    {
        public int MaintenanceRequestId { get; set; }
        public int tenantId { get; set; }
        public bool active { get; set; }
        public string message { get; set; }

        // public virtual TenantMapper Tenant { get; set; }
    }
}