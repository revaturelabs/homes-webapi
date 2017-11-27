using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.JsonModels
{
    public class HousingUnitJsonPUT
    {
        [JsonProperty("housingUnitId")]
        public int HousingUnitId { get; set; }

        [JsonProperty("providerId")]
        public int ProviderId { get; set; }

        [JsonProperty("addressId")]
        public int AddressId { get; set; }

        [JsonProperty("housingSignature")]
        public string HousingSignature { get; set; }

        [JsonProperty("capacity")]
        public int Capacity { get; set; }
    }

    public class HousingUnitJsonPOST
    {
        [JsonProperty("providerId")]
        public int ProviderId { get; set; }

        [JsonProperty("addressId")]
        public int AddressId { get; set; }

        [JsonProperty("housingSignature")]
        public string HousingSignature { get; set; }

        [JsonProperty("capacity")]
        public int Capacity { get; set; }
    }
}