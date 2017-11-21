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
using HousingAPI.Models.PresentationModels.TenantCarRelationship;

namespace HousingAPI.Controllers.APIControllers
{
    public class TenantCarRelationshipsController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/TenantCarRelationships
        [ResponseType(typeof(IEnumerable<TenantCarRelationshipMapper>))]
        public IHttpActionResult GetTenantCarRelationships()
        {
            //return db.TenantCarRelationships;
            var helper = new TenantCarRelationshipsHelper();
            var result = helper.GetTenantCarRelationships();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/TenantCarRelationships
        [ResponseType(typeof(TenantCarRelationshipMapper))]
        public IHttpActionResult GetTenantCarRelationships(int id)
        {
            //return db.TenantCarRelationships;
            var helper = new TenantCarRelationshipsHelper();
            var result = helper.GetTenantCarRelationships(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // PUT: api/TenantCarRelationships/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTenantCarRelationship(int id, [FromBody]TenantCarRelationship tenantCarRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tenantCarRelationship.relationshipId)
            {
                return BadRequest();
            }

            db.Entry(tenantCarRelationship).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantCarRelationshipExists(id))
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

        // POST: api/TenantCarRelationships
        [ResponseType(typeof(TenantCarRelationship))]
        public IHttpActionResult PostTenantCarRelationship([FromBody]TenantCarRelationship tenantCarRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TenantCarRelationships.Add(tenantCarRelationship);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tenantCarRelationship.relationshipId }, tenantCarRelationship);
        }

        // DELETE: api/TenantCarRelationships/5
        [ResponseType(typeof(TenantCarRelationship))]
        public IHttpActionResult DeleteTenantCarRelationship(int id)
        {
            TenantCarRelationship tenantCarRelationship = db.TenantCarRelationships.Find(id);
            if (tenantCarRelationship == null)
            {
                return NotFound();
            }

            db.TenantCarRelationships.Remove(tenantCarRelationship);
            db.SaveChanges();

            return Ok(tenantCarRelationship);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TenantCarRelationshipExists(int id)
        {
            return db.TenantCarRelationships.Count(e => e.relationshipId == id) > 0;
        }
    }
}