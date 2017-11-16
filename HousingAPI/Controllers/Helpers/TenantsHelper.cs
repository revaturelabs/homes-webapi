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
using HousingAPI.Models.PresentationModels.Tenant;

namespace HousingAPI.Controllers.Helpers
{
    public class TenantsHelper : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // 
        public IEnumerable<TenantMapper> GetTenants()
        {
            var content = db.Tenants.ToList();
            List<TenantMapper> tenants = new List<TenantMapper>();
            foreach (var item in content)
            {
                TenantMapper tenant = new TenantMapper
                {
                    TenantId = item.tenantId,
                    ContactId = item.contactId ?? 0,
                    BatchId = item.batchId ?? 0,
                    HousingUnitId = item.housingUnitId ?? 0,
                    GenderId = item.genderId ?? 0,
                    MoveInDate = item.moveInDate,
                    HasMoved = item.hasMoved ?? default(bool),
                    HasKey = item.hasKey ?? default(bool)
                };
                tenants.Add(tenant);
            }
            return tenants;
        }

        // 
        public TenantMapper GetTenant(int id)
        {
            var content = db.Tenants.Where(j => j.tenantId == id).FirstOrDefault();

            if (content != null)
            {
                TenantMapper tenant = new TenantMapper
                {
                    TenantId = content.tenantId,
                    ContactId = content.contactId ?? 0,
                    BatchId = content.batchId ?? 0,
                    HousingUnitId = content.housingUnitId ?? 0,
                    GenderId = content.genderId ?? 0,
                    MoveInDate = content.moveInDate,
                    HasMoved = content.hasMoved ?? default(bool),
                    HasKey = content.hasKey ?? default(bool)
                };

                return tenant;
            }
            return null;
        }

        // 
        public TenantInfoMapper GetTenantwithInfo(int id)
        {
            var content = db.Tenants.Where(j => j.tenantId == id).FirstOrDefault();

            if (content != null)
            {
                BatchesHelpers batch = new BatchesHelpers();
                GendersHelper gender = new GendersHelper();
                
                TenantInfoMapper tenant = new TenantInfoMapper
                {
                    TenantId = content.tenantId,
                    ContactId = content.contactId ?? 0,
                    BatchId = content.batchId ?? 0,
                    HousingUnitId = content.housingUnitId ?? 0,
                    GenderId = content.genderId ?? 0,
                    MoveInDate = content.moveInDate,
                    HasMoved = content.hasMoved ?? default(bool),
                    HasKey = content.hasKey ?? default(bool)
                };

                return tenant;
            }
            return null;
        }


        /*
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
        */
    }
}