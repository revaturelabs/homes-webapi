using HousingAPI.Models.PresentationModels.HousingUnit;

namespace HousingAPI.Models.PresentationModels.Tenant
{
    public class TenantProviderMapper : TenantMapper
    {
        public HousingUnitProviderMapper HousingUnit { get; set; }
    }
}