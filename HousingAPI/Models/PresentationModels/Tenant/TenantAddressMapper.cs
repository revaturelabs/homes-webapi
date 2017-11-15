using HousingAPI.Models.PresentationModels.HousingUnit;

namespace HousingAPI.Models.PresentationModels.Tenant
{
    public class TenantAddressMapper : ATenantMapper
    {
        public HousingUnitAddressMapper HousingUnit { get; set; }
    }
}