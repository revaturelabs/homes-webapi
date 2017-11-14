using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models
{
    public class TenantsGenderViewModel
    {
        public Gender gender { get; set; }
        public List<Tenant> tenants { get; set; }
    }
}