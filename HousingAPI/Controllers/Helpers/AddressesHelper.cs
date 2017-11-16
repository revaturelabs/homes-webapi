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
        
        // Get all basic table
        public IEnumerable<AddressMapper> GetAddresses()
        {
            List< Address> content = db.Addresses.ToList();
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
        
        // Get one basic table
        public AddressMapper GetAddress(int addressId)
        {
            var content = db.Addresses.Where(j => j.addressId == addressId).FirstOrDefault();
            
            if (content != null)
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
            return null;
        }

        /*
        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != address.addressId)
            {
                return BadRequest();
            }

            db.Entry(address).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Addresses
        [ResponseType(typeof(Address))]
        public IHttpActionResult PostAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Addresses.Add(address);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = address.addressId }, address);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Address))]
        public IHttpActionResult DeleteAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(address);
            db.SaveChanges();

            return Ok(address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressExists(int id)
        {
            return db.Addresses.Count(e => e.addressId == id) > 0;
        }
        */
    }
}