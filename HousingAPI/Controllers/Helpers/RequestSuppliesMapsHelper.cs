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
using HousingAPI.Models.PresentationModels.RequestSuppliesMap;

namespace HousingAPI.Controllers.Helpers
{
    public class RequestSuppliesMapsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get all request supplies maps
        public IEnumerable<RequestSuppliesMapMapper> GetRequestSuppliesMaps()
        {
            var toBeMapped = db.RequestSuppliesMaps.ToList();
            List<RequestSuppliesMapMapper> rsmml = new List<RequestSuppliesMapMapper>();
            foreach (var rsm in toBeMapped)
            {
                RequestSuppliesMapMapper rsmm = new RequestSuppliesMapMapper();
                rsmm.RequestSupplyMapId = rsm.requestSupplyMapId;
                rsmm.SuppliesRequestId = rsm.suppliesRequestId ?? default(int);
                rsmm.SupplyId = rsm.supplyId ?? default(int);
                rsmml.Add(rsmm);
            }

            return rsmml;

        }

        // Get a single request supplies map
        public RequestSuppliesMapMapper GetRequestSuppliesMap(int id)
        {
            RequestSuppliesMap requestSuppliesMap = db.RequestSuppliesMaps.FirstOrDefault();
            if (requestSuppliesMap == null)
            {
                return null;
            }
            else
            {
                RequestSuppliesMapMapper rsmm = new RequestSuppliesMapMapper();
                rsmm.RequestSupplyMapId = requestSuppliesMap.requestSupplyMapId;
                rsmm.SuppliesRequestId = requestSuppliesMap.suppliesRequestId ?? default(int);
                rsmm.SupplyId = requestSuppliesMap.supplyId ?? default(int);

                return rsmm;
            }

        }


        /*
        // PUT: api/RequestSuppliesMaps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequestSuppliesMap(int id, RequestSuppliesMap requestSuppliesMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requestSuppliesMap.requestSupplyMapId)
            {
                return BadRequest();
            }

            db.Entry(requestSuppliesMap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestSuppliesMapExists(id))
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

        // POST: api/RequestSuppliesMaps
        [ResponseType(typeof(RequestSuppliesMap))]
        public IHttpActionResult PostRequestSuppliesMap(RequestSuppliesMap requestSuppliesMap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestSuppliesMaps.Add(requestSuppliesMap);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = requestSuppliesMap.requestSupplyMapId }, requestSuppliesMap);
        }

        // DELETE: api/RequestSuppliesMaps/5
        [ResponseType(typeof(RequestSuppliesMap))]
        public IHttpActionResult DeleteRequestSuppliesMap(int id)
        {
            RequestSuppliesMap requestSuppliesMap = db.RequestSuppliesMaps.Find(id);
            if (requestSuppliesMap == null)
            {
                return NotFound();
            }

            db.RequestSuppliesMaps.Remove(requestSuppliesMap);
            db.SaveChanges();

            return Ok(requestSuppliesMap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestSuppliesMapExists(int id)
        {
            return db.RequestSuppliesMaps.Count(e => e.requestSupplyMapId == id) > 0;
        }
        */
    }
}