using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.JsonModels
{
    public class SupplyRequestJson
    {
        [JsonProperty("tenantId")]
        public int TenantId { get; set; }

        // [JsonProperty("requestSuppliesMaps")]
        public List<SupplyRequestMapJson> RequestSuppliesMaps { get; set; }
    }

    public class SupplyRequestMapJson
    {
        [JsonProperty("supplyId")]
        public int SupplyId { get; set; }
    }
}