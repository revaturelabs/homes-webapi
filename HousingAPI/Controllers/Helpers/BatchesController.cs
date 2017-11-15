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
    public class BatchesController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Batches
        public IQueryable<Batch> GetBatches()
        {
            return db.Batches;
        }

        // GET: api/Batches/5
        [ResponseType(typeof(Batch))]
        public IHttpActionResult GetBatch(int id)
        {
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return NotFound();
            }

            return Ok(batch);
        }

        // PUT: api/Batches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBatch(int id, Batch batch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != batch.batchId)
            {
                return BadRequest();
            }

            db.Entry(batch).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatchExists(id))
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

        // POST: api/Batches
        [ResponseType(typeof(Batch))]
        public IHttpActionResult PostBatch(Batch batch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Batches.Add(batch);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = batch.batchId }, batch);
        }

        // DELETE: api/Batches/5
        [ResponseType(typeof(Batch))]
        public IHttpActionResult DeleteBatch(int id)
        {
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return NotFound();
            }

            db.Batches.Remove(batch);
            db.SaveChanges();

            return Ok(batch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BatchExists(int id)
        {
            return db.Batches.Count(e => e.batchId == id) > 0;
        }
    }
}