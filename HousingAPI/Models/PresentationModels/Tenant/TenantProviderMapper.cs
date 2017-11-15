using HousingAPI.Models.PresentationModels.HousingUnit;

namespace HousingAPI.Models.PresentationModels.Tenant
{
    public class TenantProviderMapper : ATenantMapper
    {
        public HousingUnitProviderMapper HousingUnit { get; set; }
    }
}