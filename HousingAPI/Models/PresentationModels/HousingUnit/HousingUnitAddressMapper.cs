using HousingAPI.Models.HousingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.PresentationModels.HousingUnit
{
    public class HousingUnitAddressMapper : AHousingUnitMapper
    {
        public AddressMapper Address { get; set; }
    }
}