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
using HousingAPI.Controllers.Helpers;
using HousingAPI.Models.PresentationModels.HousingUnit;

namespace HousingAPI.Controllers.APIControllers
{
    public class HousingUnitsController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/HousingUnits
        [ResponseType(typeof(IEnumerable<HousingUnitMapper>))]
        public IHttpActionResult GetHousingUnits()
        {
            var helper = new HousingUnitsHelper();
            var result = helper.GetHousingUnits();
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // GET: api/HousingUnits/5
        [ResponseType(typeof(HousingUnitMapper))]
        public IHttpActionResult GetHousingUnit(int id)
        {
            var helper = new HousingUnitsHelper();
            var result = helper.GetHousingUnit(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET api/HousingUnits/WithAddresses
        [Route("api/HousingUnits/WithAddresses")]
        [ResponseType(typeof(IEnumerable<HousingUnitAddressMapper>))]
        public IHttpActionResult GetHousingUnitWithAddress()
        {
            var helper = new HousingUnitsHelper();
            var result = helper.GetHousingUnitsWithAddress();
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // GET api/HousingUnits/WithAddresses
        [Route("api/HousingUnits/WithAddresses/{id}")]
        [ResponseType(typeof(HousingUnitAddressMapper))]
        public IHttpActionResult GetHousingUnitWithAddress(int id)
        {
            var helper = new HousingUnitsHelper();
            var result = helper.GetHousingUnitWithAddress(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }
        
        //GET: api/HousingUnits/WithProviders/
        [Route("api/HousingUnits/WithProviders")]
        [ResponseType(typeof(IEnumerable<HousingUnitProviderMapper>))]
        public IHttpActionResult GetHousingUnitsWithProvider()
        {
            var helper = new HousingUnitsHelper();
            var result = helper.GetHousingUnitsWithProvider();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/HousingUnits/WithProviders/5
        [Route("api/HousingUnits/WithProviders/{id}")]
        [ResponseType(typeof(HousingUnitProviderMapper))]
        public IHttpActionResult GetHousingUnitWithProvider(int id)
        {
            var helper = new HousingUnitsHelper();
            var result = helper.GetHousingUnitWithProvider(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        //GET: api/HousingUnits/WithTenants/
        [Route("api/HousingUnits/WithTenants")]
        [ResponseType(typeof(IEnumerable<HousingUnitTenantInfoMapper>))]
        public IHttpActionResult GetHousingUnitsWithTenants()
        {
            var helper = new HousingUnitsHelper();
            var result = helper.GetHousingUnitsWithTenants();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/HousingUnits/WithTenants/5
        [Route("api/HousingUnits/WithTenants/{id}")]
        [ResponseType(typeof(HousingUnitTenantInfoMapper))]
        public IHttpActionResult GetHousingUnitWithTenants(int id)
        {
            var helper = new HousingUnitsHelper();
            var result = helper.GetHousingUnitWithTenants(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/HousingUnits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHousingUnit(int id, HousingUnit housingUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != housingUnit.housingUnitId)
            {
                return BadRequest();
            }

            db.Entry(housingUnit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HousingUnitExists(id))
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

        // POST: api/HousingUnits
        [ResponseType(typeof(HousingUnit))]
        public IHttpActionResult PostHousingUnit(HousingUnit housingUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HousingUnits.Add(housingUnit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = housingUnit.housingUnitId }, housingUnit);
        }

        // DELETE: api/HousingUnits/5
        [ResponseType(typeof(HousingUnit))]
        public IHttpActionResult DeleteHousingUnit(int id)
        {
            HousingUnit housingUnit = db.HousingUnits.Find(id);
            if (housingUnit == null)
            {
                return NotFound();
            }

            db.HousingUnits.Remove(housingUnit);
            db.SaveChanges();

            return Ok(housingUnit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HousingUnitExists(int id)
        {
            return db.HousingUnits.Count(e => e.housingUnitId == id) > 0;
        }
    }
}