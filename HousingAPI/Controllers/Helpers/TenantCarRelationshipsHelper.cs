using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.TenantCarRelationship;
using System.Collections.Generic;
using System.Linq;

namespace HousingAPI.Controllers.Helpers
{
    public class TenantCarRelationshipsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();


        public IEnumerable<TenantCarRelationshipMapper> GetTenantCarRelationships()
        {
            var content = db.TenantCarRelationships.ToList();
            List<TenantCarRelationshipMapper> tenantCarRelationships = new List<TenantCarRelationshipMapper>();
            foreach (var item in content)
            {
                TenantCarRelationshipMapper tenantCarRelationship = new TenantCarRelationshipMapper()
                {
                    RelationshipId = item.relationshipId,
                    TenantId = item.tenantId ?? default(int),
                    ParkingPassStatus = item.parkingPassStatus ?? default(bool),
                };
                tenantCarRelationships.Add(tenantCarRelationship);
            }
            return null;
        }

        public TenantCarRelationshipMapper GetTenantCarRelationship(int id)
        {
            var content = db.TenantCarRelationships.Where(j => j.relationshipId == id).FirstOrDefault();
            if (content != null)
            {
                TenantCarRelationshipMapper tenantCarRelationship = new TenantCarRelationshipMapper()
                {
                    RelationshipId = content.relationshipId,
                    TenantId = content.tenantId ?? default(int),
                    ParkingPassStatus = content.parkingPassStatus ?? default(bool),
                };
                return tenantCarRelationship;
            }

            return null;
        }


        /*
        // PUT: api/TenantCarRelationships/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTenantCarRelationship(int id, TenantCarRelationship tenantCarRelationship)
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
        public IHttpActionResult PostTenantCarRelationship(TenantCarRelationship tenantCarRelationship)
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
        */
    }
}