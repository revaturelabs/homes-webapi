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
using HousingAPI.Models.PresentationModels.SupplyRequest;

namespace HousingAPI.Controllers.Helpers
{
    public class SupplyRequestsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        //Get all supply requests
        public IEnumerable<SupplyRequestMapper> GetSupplyRequests()
        {
            var tobeMapped = db.SupplyRequests.ToList();
            List<SupplyRequestMapper> srml = new List<SupplyRequestMapper>();

            foreach (var request in tobeMapped)
            {
                SupplyRequestMapper srm = new SupplyRequestMapper();
                srm.SupplyRequestId = request.supplyRequestId;
                srm.TenantId = request.tenantId ?? default(int);
                srm.Active = request.active ?? default(bool);
                srml.Add(srm);
            }
            return srml;
        }

        //Get single supply request
        public SupplyRequestMapper GetSupplyRequest(int id)
        {
            SupplyRequest supplyRequest = db.SupplyRequests.FirstOrDefault(i => i.supplyRequestId == id);
            if (supplyRequest == null)
            {
                return null;
            }
            else
            {
                SupplyRequestMapper srm = new SupplyRequestMapper();
                SuppliesHelper sh = new SuppliesHelper();
                srm.Active = supplyRequest.active ?? default(bool);
                srm.SupplyRequestId = supplyRequest.supplyRequestId;
                srm.TenantId = supplyRequest.tenantId ?? default(int);
                return srm;
            }
        }


        /*
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
        */
    }
}
