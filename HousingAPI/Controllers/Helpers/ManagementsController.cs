using HousingAPI.Models;
using System.Collections.Generic;

namespace HousingAPI.Controllers.Helpers
{
    public class ManagementsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Managements
        public IEnumerable<Management> GetManagements()
        {
            return db.Managements;
        }

        // GET: api/Managements/5
        //[ResponseType(typeof(Management))]
        //public IHttpActionResult GetManagement(int id)
        //{
        //    Management management = db.Managements.Find(id);
        //    if (management == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(management);
        //}

        //// PUT: api/Managements/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutManagement(int id, Management management)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != management.managerId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(management).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ManagementExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Managements
        //[ResponseType(typeof(Management))]
        //public IHttpActionResult PostManagement(Management management)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Managements.Add(management);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = management.managerId }, management);
        //}

        //// DELETE: api/Managements/5
        //[ResponseType(typeof(Management))]
        //public IHttpActionResult DeleteManagement(int id)
        //{
        //    Management management = db.Managements.Find(id);
        //    if (management == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Managements.Remove(management);
        //    db.SaveChanges();

        //    return Ok(management);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ManagementExists(int id)
        //{
        //    return db.Managements.Count(e => e.managerId == id) > 0;
        //}
    }
}