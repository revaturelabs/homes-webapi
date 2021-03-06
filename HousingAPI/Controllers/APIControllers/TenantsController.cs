﻿using HousingAPI.Controllers.Helpers;
using HousingAPI.Models;
using HousingAPI.Models.JsonModels;
using HousingAPI.Models.PresentationModels.Tenant;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace HousingAPI.Controllers.APIControllers
{
    [Authorize]
    public class TenantsController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Tenants
        [ResponseType(typeof(IEnumerable<TenantMapper>))]
        public IHttpActionResult GetTenants()
        {
            var helper = new TenantsHelper();
            var result = helper.GetTenants();
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // GET: api/Tenants/5
        [ResponseType(typeof(TenantMapper))]
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
        [ResponseType(typeof(IEnumerable<TenantInfoMapper>))]
        public IHttpActionResult GetTenantsInfo()
        {
            var helper = new TenantsHelper();
            var result = helper.GetTenantsInfo();
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        //GET: api/Tenants/Pending
        [Route("api/Tenants/Pending")]
        [ResponseType(typeof(IEnumerable<TenantInfoMapper>))]
        public IHttpActionResult GetTenantsPending()
        {
            var helper = new TenantsHelper();
            var result = helper.GetTenantsPending();
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        //GET: api/Tenants/Confirmed
        [Route("api/Tenants/Confirmed")]
        [ResponseType(typeof(IEnumerable<TenantInfoMapper>))]
        public IHttpActionResult GetTenantsConfirmed()
        {
            var helper = new TenantsHelper();
            var result = helper.GetTenantsConfirmed();
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        //GET: api/Tenants/Info/{id}
        [Route("api/Tenants/Info/{id}")]
        [ResponseType(typeof(TenantInfoMapper))]
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
        [ResponseType(typeof(IEnumerable<TenantInfoMapper>))]
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
        public IHttpActionResult PutTenant(int id, [FromBody]TenantJsonPUT tenantJson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (id != tenantJson.TenantId)
            {
                return BadRequest();
            }

            var housingUnitHelpper = new HousingUnitsHelper();
            var housingUnit = housingUnitHelpper.GetHousingUnitsWithTenantsAvailable(tenantJson.HousingUnitId);

            if (housingUnit.Occupied < housingUnit.Capacity)
            {
                Tenant tenant = new Tenant
                {
                    tenantId = tenantJson.TenantId,
                    contactId = tenantJson.ContactId,
                    batchId = tenantJson.BatchId,
                    housingUnitId = tenantJson.HousingUnitId,
                    genderId = tenantJson.GenderId,
                    moveInDate = tenantJson.MoveInDate,
                    hasMoved = tenantJson.HasMoved,
                    hasKey = tenantJson.HasKey
                };

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
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        // POST: api/Tenants
        [ResponseType(typeof(Tenant))]
        public IHttpActionResult PostTenant([FromBody]TenantJsonPOST tenantJson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tenant tenant = new Tenant
            {
                contactId = tenantJson.ContactId,
                batchId = tenantJson.BatchId,
                housingUnitId = tenantJson.HousingUnitId,
                genderId = tenantJson.GenderId,
                moveInDate = tenantJson.MoveInDate,
                hasMoved = tenantJson.HasMoved,
                hasKey = tenantJson.HasKey
            };

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