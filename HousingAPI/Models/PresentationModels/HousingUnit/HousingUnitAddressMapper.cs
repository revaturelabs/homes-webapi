using HousingAPI.Models.PresentationModels.Address;

namespace HousingAPI.Models.PresentationModels.HousingUnit
{
    public class HousingUnitAddressMapper : AHousingUnitMapper
    {
        public AddressMapper Address { get; set; }
    }
}