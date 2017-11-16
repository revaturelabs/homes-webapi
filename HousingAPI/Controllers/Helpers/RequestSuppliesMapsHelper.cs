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

namespace HousingAPI.Controllers.Helpers
{
    public class RequestSuppliesMapsHelper : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/RequestSuppliesMaps
        public IQueryable<RequestSuppliesMap> GetRequestSuppliesMaps()
        {
            return db.RequestSuppliesMaps;
        }

        // GET: api/RequestSuppliesMaps/5
        [ResponseType(typeof(RequestSuppliesMap))]
        public IHttpActionResult GetRequestSuppliesMap(int id)
        {
            RequestSuppliesMap requestSuppliesMap = db.RequestSuppliesMaps.Find(id);
            if (requestSuppliesMap == null)
            {
                return NotFound();
            }

            return Ok(requestSuppliesMap);
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