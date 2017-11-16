using HousingAPI.Models;
using System.Collections.Generic;

namespace HousingAPI.Controllers.Helpers
{
    public class MaintenanceRequestsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/MaintenanceRequests
        public IEnumerable<MaintenanceRequest> GetMaintenanceRequests()
        {
            return db.MaintenanceRequests;
        }

        // GET: api/MaintenanceRequests/5
        //public IHttpActionResult GetMaintenanceRequest(int id)
        //{
        //    MaintenanceRequest maintenanceRequest = db.MaintenanceRequests.Find(id);
        //    if (maintenanceRequest == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(maintenanceRequest);
        //}


        /*
        // PUT: api/MaintenanceRequests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaintenanceRequest(int id, MaintenanceRequest maintenanceRequest)
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
        public IHttpActionResult PostMaintenanceRequest(MaintenanceRequest maintenanceRequest)
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
        */
    }
}