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
using HousingAPI.Models.PresentationModels.MaintenanceRequest;
using HousingAPI.Models.PresentationModels.HousingUnit;

namespace HousingAPI.Controllers
{
    [Authorize]
    public class MaintenanceRequestsController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        
        // GET: api/MaintenanceRequests
        [ResponseType(typeof(IEnumerable<MaintenanceRequestMapper>))]
        public IHttpActionResult GetMaintenanceRequests()
        {
            var helper = new MaintenanceRequestsHelper();
            var result = helper.GetMaintenanceRequests();
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // GET: api/MaintenanceRequests/5
        [ResponseType(typeof(MaintenanceRequestMapper))]
        public IHttpActionResult GetMaintenanceRequest(int id)
        {
            var helper = new MaintenanceRequestsHelper();
            var result = helper.GetMaintenanceRequest(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /*
        // GET: api/MaintenanceRequests/ByContact/5
        [Route("api/MaintenanceRequests/ByContact/{id}")]
        [ResponseType(typeof(IEnumerable<MaintenanceRequestMapper>))]
        public IHttpActionResult GetMaintenanceRequestsByTenant(int id)
        {
            var helper = new MaintenanceRequestsHelper();
            var result = helper.GetMaintenanceRequestsByTenant(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // GET: api/MaintenanceRequests/ByProvider
        [Route("api/MaintenanceRequests/ByProvider")]
        [ResponseType(typeof(IEnumerable<HousingUnitProviderTenantMaintenanceMapper>))]
        public IHttpActionResult GetMaintenanceRequestsByHouseUnit()
        {
            var helper = new HousingUnitsHelper();
            var result = helper.GetHousingUnitsMaintenanceRequest();
            if (result != null)
                return Ok(result);

            return NotFound();
        }
        */

        // GET: api/MaintenanceRequests/ByProvider/5
        [Route("api/MaintenanceRequests/ByProvider/{id}")]
        //[ResponseType(typeof(HousingUnitProviderTenantMaintenanceMapper))]
        [ResponseType(typeof(IEnumerable<MaintenanceRequestWithTenantMapper>))]
        public IHttpActionResult GetMaintenanceRequestsByProviderContact(int id)
        {

            var helper = new MaintenanceRequestsHelper();
            //var result = helper.GetHousingUnitsMaintenanceRequestByProvider(id);
            var result = helper.GetMaintenanceRequestsByProviderContact(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // GET: api/MaintenanceRequests/ByTenant/5
        [Route("api/MaintenanceRequests/ByTenant/{id}")]
        //[ResponseType(typeof(HousingUnitProviderTenantMaintenanceMapper))]
        [ResponseType(typeof(IEnumerable<MaintenanceRequestWithTenantMapper>))]
        public IHttpActionResult GetMaintenanceRequestsByTenantContact(int id)
        {

            var helper = new MaintenanceRequestsHelper();
            //var result = helper.GetHousingUnitsMaintenanceRequestByProvider(id);
            var result = helper.GetMaintenanceRequestsByTenantContact(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // GET: api/MaintenanceRequests/ByHousingUnit/5
        [Route("api/MaintenanceRequests/ByHousingUnit/{id}")]
        //[ResponseType(typeof(HousingUnitProviderTenantMaintenanceMapper))]
        [ResponseType(typeof(IEnumerable<MaintenanceRequestWithTenantMapper>))]
        public IHttpActionResult GetMaintenanceRequestsByTenantHousingUnit(int id)
        {

            var helper = new MaintenanceRequestsHelper();
            //var result = helper.GetHousingUnitsMaintenanceRequestByProvider(id);
            var result = helper.GetMaintenanceRequestsByTenantContact(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // GET: api/MaintenanceRequests/All
        [Route("api/MaintenanceRequests/All")]
        //[ResponseType(typeof(HousingUnitProviderTenantMaintenanceMapper))]
        [ResponseType(typeof(IEnumerable<MaintenanceRequestWithTenantMapper>))]
        public IHttpActionResult GetMaintenanceRequestsAll()
        {

            var helper = new MaintenanceRequestsHelper();
            var result = helper.GetMaintenanceRequestsAll();
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // PUT: api/MaintenanceRequests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaintenanceRequest(int id, [FromBody]MaintenanceRequest maintenanceRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maintenanceRequest.maintenanceRequestId)
            {
                return BadRequest();
            }

            db.Entry(maintenanceRequest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceRequestExists(id))
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

        // POST: api/MaintenanceRequests
        [ResponseType(typeof(MaintenanceRequest))]
        public IHttpActionResult PostMaintenanceRequest([FromBody]MaintenanceRequest maintenanceRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MaintenanceRequests.Add(maintenanceRequest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = maintenanceRequest.maintenanceRequestId }, maintenanceRequest);
        }

        // DELETE: api/MaintenanceRequests/5
        [ResponseType(typeof(MaintenanceRequest))]
        public IHttpActionResult DeleteMaintenanceRequest(int id)
        {
            MaintenanceRequest maintenanceRequest = db.MaintenanceRequests.Find(id);
            if (maintenanceRequest == null)
            {
                return NotFound();
            }

            db.MaintenanceRequests.Remove(maintenanceRequest);
            db.SaveChanges();

            return Ok(maintenanceRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaintenanceRequestExists(int id)
        {
            return db.MaintenanceRequests.Count(e => e.maintenanceRequestId == id) > 0;
        }
    }
}