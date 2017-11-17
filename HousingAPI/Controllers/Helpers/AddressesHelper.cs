using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.Address;
using System.Web.Http.ModelBinding;

namespace HousingAPI.Controllers.Helpers
{
    public class AddressesHelper
    {
        private HousingDBEntities db = new HousingDBEntities();
        
        // Get All basic tables
        public IEnumerable<AddressMapper> GetAddresses()
        {
            List<Address> content = db.Addresses.ToList();
            if (content.Count() == 0 )
            {
                return null;
            }
            else
            {
                List<AddressMapper> addresses = new List<AddressMapper>();
                foreach (var item in content)
                {
                    AddressMapper address = new AddressMapper
                    {
                        AddressId = item.addressId,
                        Name = item.name,
                        BuildingNumber = item.buildingNumber,
                        StreetName = item.streetName,
                        City = item.city,
                        Zipcode = item.zipcode,
                        State = item.state,
                        Country = item.country
                    };
                    addresses.Add(address);
                }
                return addresses;
            }
        }
        
        // Get One basic table
        public AddressMapper GetAddress(int addressId)
        {
            var content = db.Addresses.FirstOrDefault(j => j.addressId == addressId);
            
            if (content == null)
            {
                return null;
            }
            else
            {
                AddressMapper address = new AddressMapper
                {
                    AddressId = content.addressId,
                    Name = content.name,
                    BuildingNumber = content.buildingNumber,
                    StreetName = content.streetName,
                    City = content.city,
                    Zipcode = content.zipcode,
                    State = content.state,
                    Country = content.country
                };
                return address;
            }
        }
    }
}