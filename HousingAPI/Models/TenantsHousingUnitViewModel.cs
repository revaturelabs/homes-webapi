using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HousingAPI.Models;

namespace HousingAPI.Models
{
    public class TenantsHousingUnitViewModel
    {
        public HousingUnit housingUnit { get; set; }
        public List<Tenant> tenants { get; set; }
    }
}