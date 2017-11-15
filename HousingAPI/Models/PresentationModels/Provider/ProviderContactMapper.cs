using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HousingAPI.Models.HousingModels;

namespace HousingAPI.Models.PresentationModels.Provider
{
    public class ProviderContactMapper : AProviderMapper
    {
        public Contact Contact { get; set; }
    }
}