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
using HousingAPI.Models.PresentationModels.SupplyRequest;
using HousingAPI.Models.PresentationModels.HousingUnit;

namespace HousingAPI.Controllers.APIControllers
{
    public class SupplyRequestsController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();
        
        // GET: api/SupplyRequests
        [ResponseType(typeof(IEnumerable<SupplyRequestMapper>))]
        public IHttpActionResult GetSupplyRequests()
        {
            var helper = new SupplyRequestsHelper();
            var result = helper.GetSupplyRequests();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/SupplyRequests/5
        [ResponseType(typeof(SupplyRequestMapper))]
        [ResponseType(typeof(SupplyRequest))]
        public IHttpActionResult GetSupplyRequest(int id)
        {
            //SupplyRequest supplyRequest = db.SupplyRequests.Find(id);
            var helper = new SupplyRequestsHelper();
            var result = helper.GetSupplyRequest(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/SupplyRequests/ByHouseUnit
        [Route("api/SupplyRequests/ByHouseUnit")]
        [ResponseType(typeof(IEnumerable<HousingUnitProviderTenantSupplyMapper>))]
        public IHttpActionResult GetMaintenanceRequestsByHouseUnit()
        {
            var helper = new HousingUnitsHelper();
            var result = helper.GetHousingUnitsSupplyRequest();
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // GET: api/SupplyRequests/ByHouseUnit/5
        [Route("api/SupplyRequests/ByHouseUnit/{id}")]
        [ResponseType(typeof(IEnumerable<HousingUnitProviderTenantSupplyMapper>))]
        public IHttpActionResult GetMaintenanceRequestsByHouseUnit(int id)
        {
            var helper = new HousingUnitsHelper();
            var result = helper.GetHousingUnitsSupplyRequest(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        /*
        // GET: api/SupplyRequests/WithSupplies
        [Route("api/SupplyRequests/WithSupplies")]
        public IHttpActionResult GetSupplyRequestsWithSupplies()
        {
            var helper = new SupplyRequestsHelper();
            var result = helper.GetSupplyRequestsWithSupplies();
            if (result != null)
                return Ok(result);

            return NotFound();
        }
        
        // GET api/SupplyRequests/WithSupplies
        [Route("api/SupplyRequests/WithSupplies/{id}")]
        public IHttpActionResult GetSupplyRequestWithSupplies(int id)
        {
            var helper = new SupplyRequestsHelper();
            var result = helper.GetSupplyRequestWithSupplies(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }
        */

        // PUT: api/SupplyRequests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupplyRequest(int id, SupplyRequest supplyRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supplyRequest.supplyRequestId)
            {
                return BadRequest();
            }

            db.Entry(supplyRequest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplyRequestExists(id))
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

        // POST: api/SupplyRequests
        [ResponseType(typeof(SupplyRequest))]
        public IHttpActionResult PostSupplyRequest(SupplyRequest supplyRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SupplyRequests.Add(supplyRequest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = supplyRequest.supplyRequestId }, supplyRequest);
        }

        // DELETE: api/SupplyRequests/5
        [ResponseType(typeof(SupplyRequest))]
        public IHttpActionResult DeleteSupplyRequest(int id)
        {
            SupplyRequest supplyRequest = db.SupplyRequests.Find(id);
            if (supplyRequest == null)
            {
                return NotFound();
            }

            db.SupplyRequests.Remove(supplyRequest);
            db.SaveChanges();

            return Ok(supplyRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplyRequestExists(int id)
        {
            return db.SupplyRequests.Count(e => e.supplyRequestId == id) > 0;
        }
    }
}