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

        // All Batches with no connection
        public IEnumerable <ABatchMapper> GetBatches()
        {
            var content = db.Batches.ToList();
            List<ABatchMapper> batches = new List<ABatchMapper>();
            foreach(var item in content)
            {
                ABatchMapper batch = new ABatchMapper
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

        // A Batch with no connection, not used
        public ABatchMapper GetBatch(int id)
        {
            var content = db.Batches.Where(j => j.batchId == id).FirstOrDefault();

            if (content != null)
            {
                ABatchMapper batch = new ABatchMapper
                {
                    BatchId = content.batchId,
                    StartDate = content.startDate ?? default(DateTime),
                    EndDate = content.endDate ?? default(DateTime),
                    Name = content.name
                };

                return batch;
            }
            return new ABatchMapper();
        }

        // A Batch with no connection, not used
        public BatchTenantAddressMapper GetBatchwithHousingAddress(int id)
        {
            var content = db.Batches.Where(j => j.batchId == id).FirstOrDefault();
            //var reference = db.Tenants.Where(j => j.batchId == id).ToList();
            //var reference1 = db.HousingUnits.Where(j => j.Tenants) 

            if (content != null)
            {
                BatchTenantAddressMapper batch = new BatchTenantAddressMapper
                {
                    BatchId = content.batchId,
                    StartDate = content.startDate ?? default(DateTime),
                    EndDate = content.endDate ?? default(DateTime),
                    Name = content.name
                };

                return batch;
            }
            return new BatchTenantAddressMapper();
        }
    }
}