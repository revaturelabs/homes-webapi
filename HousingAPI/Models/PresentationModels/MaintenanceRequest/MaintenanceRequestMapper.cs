using HousingAPI.Models.PresentationModels.Tenant;

namespace HousingAPI.Models.HousingModels
{
    public class MaintenanceRequestMapper
    {
        public int MaintenanceRequestId { get; set; }
        public int TenantId { get; set; }
        public bool Active { get; set; }
        public string Message { get; set; }

        public TenantProviderMapper Tenant { get; set; }
    }
}