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
    public class TenantsController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // 
        public IEnumerable<ATenantMapper> GetTenants()
        {
            var content = db.Tenants.ToList();
            List<ATenantMapper> tenants = new List<ATenantMapper>();
            foreach (var item in content)
            {
                ATenantMapper tenant = new ATenantMapper
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
        public ATenantMapper GetTenant(int id)
        {
            var content = db.Tenants.Where(j => j.tenantId == id).FirstOrDefault();

            if (content != null)
            {
                ATenantMapper tenant = new ATenantMapper
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
            return new ATenantMapper();
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
            return new TenantInfoMapper();
        }
    }
}