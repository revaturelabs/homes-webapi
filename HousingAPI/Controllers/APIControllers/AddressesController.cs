﻿using System;
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
using HousingAPI.Controllers.Helpers;
using HousingAPI.Models.JsonModels;

namespace HousingAPI.Controllers.APIControllers
{
    [Authorize]
    public class AddressesController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Addresses
        [ResponseType(typeof(IEnumerable<AddressMapper>))]
        public IHttpActionResult GetAddresses()
        {
            var helper = new AddressesHelper();
            var result = helper.GetAddresses();
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(AddressMapper))]
        public IHttpActionResult GetAddress(int id)
        {
            var helper = new AddressesHelper();
            var result = helper.GetAddress(id);
            if (result != null)
                return Ok(result);

            return NotFound();

        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddress(int id, [FromBody]AddressJsonPUT addressJson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != addressJson.AddressId)
            {
                return BadRequest();
            }

            Address address = new Address
            {
                addressId = addressJson.AddressId,
                name = addressJson.Name,
                buildingNumber = addressJson.BuildingNumber,
                streetName = addressJson.StreetName,
                city = addressJson.City,
                zipcode = addressJson.Zipcode,
                state = addressJson.State,
                country = addressJson.Country
            };

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
        public IHttpActionResult PostAddress([FromBody]AddressJsonPOST addressJson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Address address = new Address
            {
                name = addressJson.Name,
                buildingNumber = addressJson.BuildingNumber,
                streetName = addressJson.StreetName,
                city = addressJson.City,
                zipcode = addressJson.Zipcode,
                state = addressJson.State,
                country = addressJson.Country
            };

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
    }
}