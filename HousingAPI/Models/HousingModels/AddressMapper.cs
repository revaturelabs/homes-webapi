using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.HousingModels
{
    public class AddressMapper
    {
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string BuildingNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public IList<HousingUnitMapper> HousingUnits { get; set; }
    }
}