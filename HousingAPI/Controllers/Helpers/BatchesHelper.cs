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
using HousingAPI.Models.PresentationModels.Batch;

namespace HousingAPI.Controllers.Helpers
{
    public class BatchesHelpers
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get All basic tables
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

        // Get one batch with its tenants
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

                    Tenant = tenants.GetTenantsInfoByBatch(content.batchId)
                };

                return batch;
            }
        }
    }
}
 