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
using HousingAPI.Models.PresentationModels.Batch;

namespace HousingAPI.Controllers.Helpers
{
    public class BatchesHelpers
    {
        private HousingDBEntities db = new HousingDBEntities();

        // All Batches with no connection
        public IEnumerable <BatchMapper> GetBatches()
        {
            var content = db.Batches.ToList();
            List<BatchMapper> batches = new List<BatchMapper>();
            foreach(var item in content)
            {
                BatchMapper batch = new BatchMapper
                {
                    BatchId = item.batchId,
                    StartDate = item.startDate ?? default(DateTime),
                    EndDate = item.endDate ?? default(DateTime),
                    Name = item.name
                };
                batches.Add(batch);
            }
            return batches;
        }

        // A Batch with no connection, not used
        public BatchMapper GetBatch(int batchId)
        {
            var content = db.Batches.Where(j => j.batchId == batchId).FirstOrDefault();

            if (content == null)
            {
                return null;
            }
            else
            {
                BatchMapper batch = new BatchMapper
                {
                    BatchId = content.batchId,
                    StartDate = content.startDate ?? default(DateTime),
                    EndDate = content.endDate ?? default(DateTime),
                    Name = content.name
                };

                return batch;
            }
        }

        // A Batch with no connection, not used
        public BatchTenantAddressMapper GetBatchwithHousingAddress(int batchId)
        {
            var content = db.Batches.Where(j => j.batchId == batchId).FirstOrDefault();

            if (content == null)
            {
                return null;
            }
            else
            {
                BatchTenantAddressMapper batch = new BatchTenantAddressMapper
                {
                    BatchId = content.batchId,
                    StartDate = content.startDate ?? default(DateTime),
                    EndDate = content.endDate ?? default(DateTime),
                    Name = content.name
                };

                return batch;
            }
        }


        /*
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
        */
    }
}
 