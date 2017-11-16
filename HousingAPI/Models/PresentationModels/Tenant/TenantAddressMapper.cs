using HousingAPI.Models.PresentationModels.HousingUnit;

namespace HousingAPI.Models.PresentationModels.Tenant
{
    public class TenantAddressMapper : TenantMapper
    {
        public HousingUnitAddressMapper HousingUnit { get; set; }
    }
}