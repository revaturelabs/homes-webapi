using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.Tenant;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HousingAPI.Controllers.Helpers
{
    public class TenantsHelper
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
        public IEnumerable<TenantBatchMapper> GetTenantsWithInfo()
        {
            var content = db.Tenants.ToList();
            List<TenantBatchMapper> tenants = new List<TenantBatchMapper>();
            foreach (var item in content)
            {
                BatchesHelpers batch = new BatchesHelpers();
                ContactsHelper contact = new ContactsHelper();
                GendersHelper gender = new GendersHelper();
                TenantCarRelationshipsHelper tenantCarRelationships = new TenantCarRelationshipsHelper();

                TenantBatchMapper tenant = new TenantBatchMapper
                {
                    TenantId = item.tenantId,
                    ContactId = item.contactId ?? 0,
                    BatchId = item.batchId ?? 0,
                    HousingUnitId = item.housingUnitId ?? 0,
                    GenderId = item.genderId ?? 0,
                    MoveInDate = item.moveInDate,
                    HasMoved = item.hasMoved ?? default(bool),
                    HasKey = item.hasKey ?? default(bool),

                    Batch = batch.GetBatch(item.batchId ?? 0),
                    Contact = contact.GetContact(item.contactId ?? 0),
                    Gender = gender.GetGender(item.genderId ?? 0),
                    TenantCarRelationships = tenantCarRelationships.GetTenantCarRelationship(item.tenantId)
                };
                tenants.Add(tenant);
            }
            return tenants;
        }

        // 
        public IEnumerable<TenantBatchMapper> GetTenantsWithInfoByBatch(int batchId)
        {
            var content = db.Tenants.Where(j => j.batchId == batchId).ToList();
            List<TenantBatchMapper> tenants = new List<TenantBatchMapper>();
            foreach (var item in content)
            {
                BatchesHelpers batch = new BatchesHelpers();
                ContactsHelper contact = new ContactsHelper();
                GendersHelper gender = new GendersHelper();
                TenantCarRelationshipsHelper tenantCarRelationships = new TenantCarRelationshipsHelper();

                TenantBatchMapper tenant = new TenantBatchMapper
                {
                    TenantId = item.tenantId,
                    ContactId = item.contactId ?? 0,
                    BatchId = item.batchId ?? 0,
                    HousingUnitId = item.housingUnitId ?? 0,
                    GenderId = item.genderId ?? 0,
                    MoveInDate = item.moveInDate,
                    HasMoved = item.hasMoved ?? default(bool),
                    HasKey = item.hasKey ?? default(bool),

                    Batch = batch.GetBatch(item.batchId ?? 0),
                    Contact = contact.GetContact(item.contactId ?? 0),
                    Gender = gender.GetGender(item.genderId ?? 0),
                    TenantCarRelationships = tenantCarRelationships.GetTenantCarRelationship(item.tenantId)
                };
                tenants.Add(tenant);
            }
            return tenants;
        }

        // 
        public IEnumerable<TenantBatchMapper> GetTenantsWithInfoByHousing(int housingId)
        {
            var content = db.Tenants.Where(j => j.housingUnitId == housingId).ToList();
            List<TenantBatchMapper> tenants = new List<TenantBatchMapper>();
            foreach (var item in content)
            {
                BatchesHelpers batch = new BatchesHelpers();
                ContactsHelper contact = new ContactsHelper();
                GendersHelper gender = new GendersHelper();
                TenantCarRelationshipsHelper tenantCarRelationships = new TenantCarRelationshipsHelper();

                TenantBatchMapper tenant = new TenantBatchMapper
                {
                    TenantId = item.tenantId,
                    ContactId = item.contactId ?? 0,
                    BatchId = item.batchId ?? 0,
                    HousingUnitId = item.housingUnitId ?? 0,
                    GenderId = item.genderId ?? 0,
                    MoveInDate = item.moveInDate,
                    HasMoved = item.hasMoved ?? default(bool),
                    HasKey = item.hasKey ?? default(bool),

                    Batch = batch.GetBatch(item.batchId ?? 0),
                    Contact = contact.GetContact(item.contactId ?? 0),
                    Gender = gender.GetGender(item.genderId ?? 0),
                    TenantCarRelationships = tenantCarRelationships.GetTenantCarRelationship(item.tenantId)
                };
                tenants.Add(tenant);
            }
            return tenants;
        }

        // 
        public TenantBatchMapper GetTenantWithInfo(int id)
        {
            var content = db.Tenants.Where(j => j.tenantId == id).FirstOrDefault();

            if (content != null)
            {
                BatchesHelpers batch = new BatchesHelpers();
                ContactsHelper contact = new ContactsHelper();
                GendersHelper gender = new GendersHelper();
                TenantCarRelationshipsHelper tenantCarRelationships = new TenantCarRelationshipsHelper();


                TenantBatchMapper tenant = new TenantBatchMapper
                {
                    TenantId = content.tenantId,
                    ContactId = content.contactId ?? 0,
                    BatchId = content.batchId ?? 0,
                    HousingUnitId = content.housingUnitId ?? 0,
                    GenderId = content.genderId ?? 0,
                    MoveInDate = content.moveInDate,
                    HasMoved = content.hasMoved ?? default(bool),
                    HasKey = content.hasKey ?? default(bool),

                    Batch = batch.GetBatch(content.batchId ?? 0),
                    Contact = contact.GetContact(content.contactId ?? 0),
                    Gender = gender.GetGender(content.genderId ?? 0),
                    TenantCarRelationships = tenantCarRelationships.GetTenantCarRelationship(content.tenantId)
                };

                return tenant;
            }
            return null;
        }

        //
        public IEnumerable<TenantAddressMapper> GetTenantsWithAddress()
        {
            var content = db.Tenants.ToList();
            List<TenantAddressMapper> tenants = new List<TenantAddressMapper>();
            foreach (var item in content)
            {
                HousingUnitsHelper housingUnits = new HousingUnitsHelper();
                ContactsHelper contact = new ContactsHelper();
                GendersHelper gender = new GendersHelper();
                TenantCarRelationshipsHelper car = new TenantCarRelationshipsHelper();

                TenantAddressMapper tenant = new TenantAddressMapper
                {
                    TenantId = item.tenantId,
                    ContactId = item.contactId ?? 0,
                    BatchId = item.batchId ?? 0,
                    HousingUnitId = item.housingUnitId ?? 0,
                    GenderId = item.genderId ?? 0,
                    MoveInDate = item.moveInDate,
                    HasMoved = item.hasMoved ?? default(bool),
                    HasKey = item.hasKey ?? default(bool),

                    HousingUnit = housingUnits.GetHousingUnitWithAddress(item.housingUnitId ?? 0),
                    Contact = contact.GetContact(item.contactId ?? 0),
                    Gender = gender.GetGender(item.genderId ?? 0),
                    TenantCarRelationships = car.GetTenantCarRelationship(item.tenantId)
                };
                tenants.Add(tenant);
            }
            return tenants;
        }

        //
        /*
        public IEnumerable<TenantAddressMapper> GetTenantWithAddressByBatch(int batchId)
        {
            var content = db.Tenants.Where(j => j.batchId == batchId).ToList();
            List<TenantAddressMapper> tenants = new List<TenantAddressMapper>();
            foreach (var item in content)
            {
                HousingUnitsHelper housingUnits = new HousingUnitsHelper();

                TenantAddressMapper tenant = new TenantAddressMapper
                {
                    TenantId = item.tenantId,
                    ContactId = item.contactId ?? 0,
                    BatchId = item.batchId ?? 0,
                    HousingUnitId = item.housingUnitId ?? 0,
                    GenderId = item.genderId ?? 0,
                    MoveInDate = item.moveInDate,
                    HasMoved = item.hasMoved ?? default(bool),
                    HasKey = item.hasKey ?? default(bool),

                    HousingUnit = housingUnits.GetHousingUnitWithAddress(item.housingUnitId ?? 0)

                };
                tenants.Add(tenant);
            }
            return tenants;
        }
        */

        //
        public TenantAddressMapper GetTenantWithAddress(int id)
        {
            var content = db.Tenants.Where(j => j.tenantId == id).FirstOrDefault();

            if (content != null)
            {

                HousingUnitsHelper housingUnits = new HousingUnitsHelper();
                ContactsHelper contact = new ContactsHelper();
                GendersHelper gender = new GendersHelper();
                TenantCarRelationshipsHelper car = new TenantCarRelationshipsHelper();

                TenantAddressMapper tenant = new TenantAddressMapper
                {
                    TenantId = content.tenantId,
                    ContactId = content.contactId ?? 0,
                    BatchId = content.batchId ?? 0,
                    HousingUnitId = content.housingUnitId ?? 0,
                    GenderId = content.genderId ?? 0,
                    MoveInDate = content.moveInDate,
                    HasMoved = content.hasMoved ?? default(bool),
                    HasKey = content.hasKey ?? default(bool),

                    HousingUnit = housingUnits.GetHousingUnitWithAddress(content.housingUnitId ?? 0),
                    Contact = contact.GetContact(content.contactId ?? 0),
                    Gender = gender.GetGender(content.genderId ?? 0),
                    TenantCarRelationships = car.GetTenantCarRelationship(content.tenantId)
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