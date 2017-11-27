using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.JsonModels
{
    public class TenantJsonPUT
    {
        [JsonProperty("tenantId")]
        public int TenantId { get; set; }

        [JsonProperty("contactId")]
        public int ContactId { get; set; }

        [JsonProperty("batchId")]
        public int BatchId { get; set; }

        [JsonProperty("housingUnitId")]
        public int HousingUnitId { get; set; }

        [JsonProperty("genderId")]
        public int GenderId { get; set; }

        [JsonProperty("moveInDate")]
        public DateTime MoveInDate { get; set; }

        [JsonProperty("hasMoved")]
        public bool HasMoved { get; set; }

        [JsonProperty("hasKey")]
        public bool HasKey { get; set; }
    }

    public class TenantJsonPOST
    {
        [JsonProperty("contactId")]
        public int ContactId { get; set; }

        [JsonProperty("batchId")]
        public int BatchId { get; set; }

        [JsonProperty("housingUnitId")]
        public int HousingUnitId { get; set; }

        [JsonProperty("genderId")]
        public int GenderId { get; set; }

        [JsonProperty("moveInDate")]
        public DateTime MoveInDate { get; set; }

        [JsonProperty("hasMoved")]
        public bool HasMoved { get; set; }

        [JsonProperty("hasKey")]
        public bool HasKey { get; set; }
    }
}