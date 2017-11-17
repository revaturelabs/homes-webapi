using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.MaintenanceRequest;
using System.Collections.Generic;
using System.Linq;

namespace HousingAPI.Controllers.Helpers
{
    public class MaintenanceRequestsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get all basic tables
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

        //Get one basic table
        public MaintenanceRequestMapper GetMaintenanceRequest(int maintenanceId)
        {
            MaintenanceRequest maintenanceRequest = db.MaintenanceRequests.FirstOrDefault(i => i.maintenanceRequestId == maintenanceId);
            if (maintenanceRequest == null)
            {
                return null;
            }
            else
            {
                MaintenanceRequestMapper mrm = new MaintenanceRequestMapper();
                mrm.Active = maintenanceRequest.active ?? default(bool);
                mrm.MaintenanceRequestId = maintenanceRequest.maintenanceRequestId;
                mrm.Message = maintenanceRequest.message;
                mrm.TenantId = maintenanceRequest.tenantId ?? default(int);

                return mrm;
            }
        }

        // Get one basic table
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
    }
}