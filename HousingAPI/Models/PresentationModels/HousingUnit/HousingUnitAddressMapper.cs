using HousingAPI.Models.PresentationModels.Address;

namespace HousingAPI.Models.PresentationModels.HousingUnit
{
    public class HousingUnitAddressMapper : HousingUnitMapper
    {
        public AddressMapper Address { get; set; }
    }
}