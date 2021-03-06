﻿using HousingAPI.Models.PresentationModels.Address;
using HousingAPI.Models.PresentationModels.Provider;

namespace HousingAPI.Models.PresentationModels.HousingUnit
{
    public class HousingUnitProviderMapper : HousingUnitMapper
    {
        public AddressMapper Address { get; set; }
        public ProviderContactMapper Provider { get; set; }
    }
}