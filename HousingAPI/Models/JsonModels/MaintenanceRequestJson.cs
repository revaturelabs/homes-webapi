using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.JsonModels
{
    public class MaintenanceRequestJsonPUT
    {
        [JsonProperty("maintenanceRequestId")]
        public int MaintenanceRequestId { get; set; }

        [JsonProperty("tenantId")]
        public int TenantId { get; set; }

        [JsonProperty("message")]
        public String Message { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

    }

    public class MaintenanceRequestJsonPOST
    {
        [JsonProperty("tenantId")]
        public int TenantId { get; set; }

        [JsonProperty("message")]
        public String Message { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

    }
}