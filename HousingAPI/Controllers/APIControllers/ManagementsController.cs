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
    public class ManagementsController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Managements
        public IQueryable<Management> GetManagements()
        {
            return db.Managements;
        }

        // GET: api/Managements/5
        [ResponseType(typeof(Management))]
        public IHttpActionResult GetManagement(int id)
        {
            Management management = db.Managements.Find(id);
            if (management == null)
            {
                return NotFound();
            }

            return Ok(management);
        }

        // PUT: api/Managements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutManagement(int id, Management management)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != management.managerId)
            {
                return BadRequest();
            }

            db.Entry(management).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagementExists(id))
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

        // POST: api/Managements
        [ResponseType(typeof(Management))]
        public IHttpActionResult PostManagement(Management management)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Managements.Add(management);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = management.managerId }, management);
        }

        // DELETE: api/Managements/5
        [ResponseType(typeof(Management))]
        public IHttpActionResult DeleteManagement(int id)
        {
            Management management = db.Managements.Find(id);
            if (management == null)
            {
                return NotFound();
            }

            db.Managements.Remove(management);
            db.SaveChanges();

            return Ok(management);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManagementExists(int id)
        {
            return db.Managements.Count(e => e.managerId == id) > 0;
        }
    }
}