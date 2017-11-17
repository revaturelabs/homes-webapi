﻿using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.MaintenanceRequest;
using System.Collections.Generic;
using System.Linq;

namespace HousingAPI.Controllers.Helpers
{
    public class MaintenanceRequestsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get All basic tables
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
    }
}