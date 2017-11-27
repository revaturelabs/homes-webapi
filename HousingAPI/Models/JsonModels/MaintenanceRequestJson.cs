using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.JsonModels
{
    public class MaintenanceRequestJson
    {
        [JsonProperty("tenantId")]
        public int TenantId { get; set; }

        [JsonProperty("message")]
        public String Message { get; set; }
    }
}