using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.MaintenanceRequest;
using System.Collections.Generic;
using System.Linq;

namespace HousingAPI.Controllers.Helpers
{
    public class MaintenanceRequestsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get All basic tables
        // DEFAULT CRUD
        public IEnumerable<MaintenanceRequestMapper> GetMaintenanceRequests()
        {
            var content = db.MaintenanceRequests.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<MaintenanceRequestMapper> requests = new List<MaintenanceRequestMapper>();
                foreach (var item in content)
                {
                    MaintenanceRequestMapper request = new MaintenanceRequestMapper
                    {
                        Active = item.active ?? default(bool),
                        MaintenanceRequestId = item.maintenanceRequestId,
                        Message = item.message,
                        TenantId = item.tenantId ?? default(int)
                    };
                    requests.Add(request);
                }
                return requests;
            }
        }

        //Get One basic table
        // DEFAULT CRUD
        public MaintenanceRequestMapper GetMaintenanceRequest(int maintenanceId)
        {
            MaintenanceRequest content = db.MaintenanceRequests.FirstOrDefault(i => i.maintenanceRequestId == maintenanceId);
            if (content == null)
            {
                return null;
            }
            else
            {
                MaintenanceRequestMapper maintenance = new MaintenanceRequestMapper
                {
                    Active = content.active ?? default(bool),
                    MaintenanceRequestId = content.maintenanceRequestId,
                    Message = content.message,
                    TenantId = content.tenantId ?? default(int)
                };
                return maintenance;
            }
        }

        // Get One basic table, used for housing maintenace request
        // INSIDE HELPER: USED IN TENANTS
        // RETURNS A LIST OF MAINTENANCE REQUESTS BY TENANT ID
        public IEnumerable<MaintenanceRequestMapper> GetMaintenanceRequestsByTenant(int tenantId)
        {
            var content = db.MaintenanceRequests.Where(j => j.tenantId == tenantId).ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<MaintenanceRequestMapper> requests = new List<MaintenanceRequestMapper>();
                foreach (var item in content)
                {
                    MaintenanceRequestMapper request = new MaintenanceRequestMapper
                    {
                        Active = item.active ?? default(bool),
                        MaintenanceRequestId = item.maintenanceRequestId,
                        Message = item.message,
                        TenantId = item.tenantId ?? default(int)
                    };
                    requests.Add(request);
                }
                return requests;
            }
        }

        // Get One basic table, used for housing maintenace request
        // DEFAULT
        // RETURNS A LIST OF MAINTENANCE REQUESTS BY TENANT ID
        public IEnumerable<MaintenanceRequestMapper> GetMaintenanceRequestsByContact(int contactId)
        {
            var content = db.MaintenanceRequests.Where(j => j.Tenant.contactId == contactId).ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<MaintenanceRequestMapper> requests = new List<MaintenanceRequestMapper>();
                foreach (var item in content)
                {
                    MaintenanceRequestMapper request = new MaintenanceRequestMapper
                    {
                        Active = item.active ?? default(bool),
                        MaintenanceRequestId = item.maintenanceRequestId,
                        Message = item.message,
                        TenantId = item.tenantId ?? default(int)
                    };
                    requests.Add(request);
                }
                return requests;
            }
        }

        // Get One basic table, used for housing maintenace request
        // DEFAULT
        // RETURNS A LIST OF MAINTENANCE REQUESTS BY PROVIDER ID
        public IEnumerable<MaintenanceRequestWithTenantMapper> GetMaintenanceRequestsProvider(int contactId)
        { 
            var content = db.MaintenanceRequests.Where(j => j.Tenant.HousingUnit.Provider.contactId == contactId).ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<MaintenanceRequestWithTenantMapper> requests = new List<MaintenanceRequestWithTenantMapper>();
                TenantsHelper tenant = new TenantsHelper();
                foreach (var item in content)
                {
                    MaintenanceRequestWithTenantMapper request = new MaintenanceRequestWithTenantMapper
                    {
                        Active = item.active ?? default(bool),
                        MaintenanceRequestId = item.maintenanceRequestId,
                        Message = item.message,
                        TenantId = item.tenantId ?? default(int),

                        Tenant = tenant.GetTenantForRequests(item.tenantId ?? 0)
                    };
                    requests.Add(request);
                }
                return requests;
            }
        }
    }
}