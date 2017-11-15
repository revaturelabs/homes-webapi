using HousingAPI.Models.PresentationModels.HousingUnit;
using System.Collections.Generic;

namespace HousingAPI.Models.PresentationModels.Provider
{
    public class ProviderUnitsMapper : AProviderMapper
    {
        public IEnumerable<HousingUnitAddressMapper> HousingUnits { get; set; }
    }
}