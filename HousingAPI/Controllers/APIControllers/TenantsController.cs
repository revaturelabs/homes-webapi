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

namespace HousingAPI.Controllers.APIControllers
{
    public class TenantsController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Tenants
        public IHttpActionResult GetTenants()
        {
            var helper = new TenantsHelper();
            var result = helper.GetTenants();
            if (result != null)
                return Ok(result);

            return NotFound();
        }
        // GET: api/Tenants/5
        [ResponseType(typeof(Tenant))]
        public IHttpActionResult GetTenant(int id)
        {
            var helper = new TenantsHelper();
            var result = helper.GetTenant(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        //GET: api/Tenants/Info
        [Route("api/Tenants/Info")]
        public IHttpActionResult GetTenantsInfo()
        {
            var helper = new TenantsHelper();
            var result = helper.GetTenantsInfo();
            if (result != null)
                return Ok(result);

            return NotFound();
        }
        //GET: api/Tenants/Info/{id}
        [Route("api/Tenants/Info/{id}")]
        public IHttpActionResult GetTenantInfo(int id)
        {
            var helper = new TenantsHelper();
            var result = helper.GetTenantInfo(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        //GET: api/Tenants/Info/ByBatch/5
        [Route("api/Tenants/Info/ByBatch/{id}")]
        public IHttpActionResult GetTenantsInfoByBatch(int id)
        {
            var helper = new TenantsHelper();
            var result = helper.GetTenantsInfoByBatch(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        // PUT: api/Tenants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTenant(int id, Tenant tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tenant.tenantId)
            {
                return BadRequest();
            }

            db.Entry(tenant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(id))
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

        // POST: api/Tenants
        [ResponseType(typeof(Tenant))]
        public IHttpActionResult PostTenant(Tenant tenant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tenants.Add(tenant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tenant.tenantId }, tenant);
        }

        // DELETE: api/Tenants/5
        [ResponseType(typeof(Tenant))]
        public IHttpActionResult DeleteTenant(int id)
        {
            Tenant tenant = db.Tenants.Find(id);
            if (tenant == null)
            {
                return NotFound();
            }

            db.Tenants.Remove(tenant);
            db.SaveChanges();

            return Ok(tenant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TenantExists(int id)
        {
            return db.Tenants.Count(e => e.tenantId == id) > 0;
        }
    }
}