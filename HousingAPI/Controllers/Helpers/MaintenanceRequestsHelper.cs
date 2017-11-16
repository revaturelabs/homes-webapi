using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.MaintenanceRequest;
using System.Collections.Generic;
using System.Linq;

namespace HousingAPI.Controllers.Helpers
{
    public class MaintenanceRequestsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get all simple maintenance requests
        public IEnumerable<MaintenanceRequestMapper> GetMaintenanceRequests()
        {
            var content = db.MaintenanceRequests.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<MaintenanceRequestMapper> mrml = new List<MaintenanceRequestMapper>();
                foreach (var maintenanceRequest in content)
                {
                    MaintenanceRequestMapper mrm = new MaintenanceRequestMapper();
                    mrm.Active = maintenanceRequest.active ?? default(bool);
                    mrm.MaintenanceRequestId = maintenanceRequest.maintenanceRequestId;
                    mrm.Message = maintenanceRequest.message;
                    mrm.TenantId = maintenanceRequest.tenantId ?? default(int);

                    mrml.Add(mrm);

                }

                return mrml;
            }


        }

        ////Get single simple maintenance request
        //public MaintenanceRequestMapper GetMaintenanceRequest(int id)
        //{
        //    MaintenanceRequest maintenanceRequest = db.MaintenanceRequests.FirstOrDefault(i => i.maintenanceRequestId == id);
        //    if (maintenanceRequest == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        MaintenanceRequestMapper mrm = new MaintenanceRequestMapper();
        //        mrm.Active = maintenanceRequest.active ?? default(bool);
        //        mrm.MaintenanceRequestId = maintenanceRequest.maintenanceRequestId;
        //        mrm.Message = maintenanceRequest.message;
        //        mrm.TenantId = maintenanceRequest.tenantId ?? default(int);

        //        return mrm;
        //    }
        //}

        ////Get all maintenance requests with providers
        //public IEnumerable<MaintenanceRequestTenantProviderMapper> GetMaintenanceRequestsForProvider(int providerId)
        //{
        //    TenantsHelper tenantsHelper = new TenantsHelper();
        //    ProvidersHelper providersHelper = new ProvidersHelper();

        //    var housingUnitsForSpecificProvider = providersHelper.GetProviderWithUnit(providerId).HousingUnits;
        //    var tenants = tenantsHelper.GetTenants();
        //    var maintenanceRequests = GetMaintenanceRequests();

        //    if (tenantsWithProvider.Count() == 0 || maintenanceRequests.Count() == 0)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        var maintenanceRequestForSpecificProvider = 

        //        List<MaintenanceRequestTenantProviderMapper> mrtpm = new List<MaintenanceRequestTenantProviderMapper>();
        //        foreach (var maintenanceRequest in maintenanceRequests)
        //        {
        //            MaintenanceRequestMapper mrm = new MaintenanceRequestMapper();
        //            mrm.Active = maintenanceRequest.active ?? default(bool);
        //            mrm.MaintenanceRequestId = maintenanceRequest.maintenanceRequestId;
        //            mrm.Message = maintenanceRequest.message;
        //            mrm.TenantId = maintenanceRequest.tenantId ?? default(int);

        //            mrml.Add(mrm);

        //        }

        //        return mrml;
        //    }


        //}

        /*
        // PUT: api/MaintenanceRequests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaintenanceRequest(int id, MaintenanceRequest maintenanceRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maintenanceRequest.maintenanceRequestId)
            {
                return BadRequest();
            }

            db.Entry(maintenanceRequest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceRequestExists(id))
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

        // POST: api/MaintenanceRequests
        [ResponseType(typeof(MaintenanceRequest))]
        public IHttpActionResult PostMaintenanceRequest(MaintenanceRequest maintenanceRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MaintenanceRequests.Add(maintenanceRequest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = maintenanceRequest.maintenanceRequestId }, maintenanceRequest);
        }

        // DELETE: api/MaintenanceRequests/5
        [ResponseType(typeof(MaintenanceRequest))]
        public IHttpActionResult DeleteMaintenanceRequest(int id)
        {
            MaintenanceRequest maintenanceRequest = db.MaintenanceRequests.Find(id);
            if (maintenanceRequest == null)
            {
                return NotFound();
            }

            db.MaintenanceRequests.Remove(maintenanceRequest);
            db.SaveChanges();

            return Ok(maintenanceRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaintenanceRequestExists(int id)
        {
            return db.MaintenanceRequests.Count(e => e.maintenanceRequestId == id) > 0;
        }
        */
    }
}