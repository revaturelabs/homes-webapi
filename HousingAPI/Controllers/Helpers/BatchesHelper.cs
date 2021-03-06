﻿using System;
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
using HousingAPI.Models.PresentationModels.Batch;

namespace HousingAPI.Controllers.Helpers
{
    public class BatchesHelpers
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get All basic tables
        // DEFAULT CRUD
        public IEnumerable <BatchMapper> GetBatches()
        {
            var content = db.Batches.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<BatchMapper> batches = new List<BatchMapper>();
                foreach (var item in content)
                {
                    BatchMapper batch = new BatchMapper
                    {
                        BatchId = item.batchId,
                        StartDate = item.startDate ?? default(DateTime),
                        EndDate = item.endDate ?? default(DateTime),
                        Name = item.name
                    };
                    batches.Add(batch);
                }
                return batches;
            }
        }

        // Get One basic table
        // DEFAULT CRUD
        public BatchMapper GetBatch(int batchId)
        {
            var content = db.Batches.FirstOrDefault(j => j.batchId == batchId);
            if (content == null)
            {
                return null;
            }
            else
            {
                BatchMapper batch = new BatchMapper
                {
                    BatchId = content.batchId,
                    StartDate = content.startDate ?? default(DateTime),
                    EndDate = content.endDate ?? default(DateTime),
                    Name = content.name
                };

                return batch;
            }
        }

        // Get One batch with its tenants
        // DEFAULT
        // RETURNS A BATCH WITH: Tenants with Housing unitt with Address, Contact, Gender and Car relationship
        public BatchTenantMapper GetBatchwithHousingAddress(int batchId)
        {
            var content = db.Batches.FirstOrDefault(j => j.batchId == batchId);
            if (content == null)
            {
                return null;
            }
            else
            {
                TenantsHelper tenants = new TenantsHelper();
                BatchTenantMapper batch = new BatchTenantMapper
                {
                    BatchId = content.batchId,
                    StartDate = content.startDate ?? default(DateTime),
                    EndDate = content.endDate ?? default(DateTime),
                    Name = content.name,

                    Tenant = tenants.GetTenantsAddressByBatch(content.batchId)
                };
                return batch;
            }
        }
    }
}
 