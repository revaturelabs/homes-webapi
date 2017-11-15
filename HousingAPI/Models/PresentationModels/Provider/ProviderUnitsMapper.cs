 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 using HousingAPI.Models.HousingModels;
using HousingAPI.Models.PresentationModels.HousingUnit;

namespace HousingAPI.Models.PresentationModels.Provider
{
    public class ProviderUnitsMapper : AProviderMapper
    {
        public IEnumerable<HousingUnitAddressMapper> HousingUnits { get; set; }
    }
}