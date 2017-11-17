using HousingAPI.Models.PresentationModels.Supply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.PresentationModels.RequestSuppliesMap
{
    public class RequestSuppliesMapSupplyMapper : RequestSuppliesMapMapper
    {
        public SupplyMapper Supply { get; set; }
    }
}