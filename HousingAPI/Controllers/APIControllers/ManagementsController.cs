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
using HousingAPI.Models.PresentationModels.Management;
using HousingAPI.Models.PresentationModels.HousingUnit;

namespace HousingAPI.Controllers.APIControllers
{
    [Authorize]
    public class ManagementsController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Managements
        [ResponseType(typeof(IEnumerable<ManagementMapper>))]
        public IHttpActionResult GetManagements()
        {
            var helper = new ManagementsHelper();
            var result = helper.GetManagements();
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // GET: api/Managements/5
        [ResponseType(typeof(ManagementMapper))]
        public IHttpActionResult GetManagement(int id)
        {
            var helper = new ManagementsHelper();
            var result = helper.GetManagement(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/Managements
        [ResponseType(typeof(IEnumerable<ManagementContactMapper>))]
        [Route("api/Managements/WithContact")]
        public IHttpActionResult GetManagementsWithContact()
        {
            var helper = new ManagementsHelper();
            var result = helper.GetManagementsWithContact();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/Managements/WithContact/5
        [ResponseType(typeof(ManagementContactMapper))]
        [Route("api/Managements/WithContact/{id}")]
        public IHttpActionResult GetManagementWithContact(int id)
        {
            var helper = new ManagementsHelper();
            var result = helper.GetManagementWithContact(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/Managements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutManagement(int id, [FromBody]Management management)
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
        public IHttpActionResult PostManagement([FromBody]Management management)
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