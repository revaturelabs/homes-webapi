using HousingAPI.Models.PresentationModels.Tenant;

namespace HousingAPI.Models.PresentationModels.MaintenanceRequest
{
    public class MaintenanceRequestMapper
    {
        public int MaintenanceRequestId { get; set; }
        public int TenantId { get; set; }
        public bool Active { get; set; }
        public string Message { get; set; }
    }
}