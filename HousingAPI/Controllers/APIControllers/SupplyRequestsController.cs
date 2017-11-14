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

namespace HousingAPI.Controllers.APIControllers
{
    public class SupplyRequestsController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/SupplyRequests
        public IQueryable<SupplyRequest> GetSupplyRequests()
        {
            return db.SupplyRequests;
        }

        // GET: api/SupplyRequests/5
        [ResponseType(typeof(SupplyRequest))]
        public IHttpActionResult GetSupplyRequest(int id)
        {
            SupplyRequest supplyRequest = db.SupplyRequests.Find(id);
            if (supplyRequest == null)
            {
                return NotFound();
            }

            return Ok(supplyRequest);
        }

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