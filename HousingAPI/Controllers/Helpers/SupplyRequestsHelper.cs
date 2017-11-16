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
using HousingAPI.Models.PresentationModels.SupplyRequest;

namespace HousingAPI.Controllers.Helpers
{
    public class SupplyRequestsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        //Get all supply requests
        public IEnumerable<SupplyRequestMapper> GetSupplyRequests()
        {
            var tobeMapped = db.SupplyRequests.ToList();
            List<SupplyRequestMapper> srml = new List<SupplyRequestMapper>();

            foreach (var request in tobeMapped)
            {
                SupplyRequestMapper srm = new SupplyRequestMapper();
                srm.SupplyRequestId = request.supplyRequestId;
                srm.TenantId = request.tenantId ?? 0;
                srm.Active = request.active ?? false;
                srml.Add(srm);
            }
            return srml;
        }

        //Get single supply request
        public SupplyRequestMapper GetSupplyRequest(int id)
        {
            SupplyRequest supplyRequest = db.SupplyRequests.FirstOrDefault(i => i.supplyRequestId == id);
            if (supplyRequest == null)
            {
                SupplyRequestMapper srm = new SupplyRequestMapper();
                return srm;
            }

            else
            {
                SupplyRequestMapper srm = new SupplyRequestMapper();
                SuppliesHelper sh = new SuppliesHelper();
                srm.Active = supplyRequest.active ?? false;
                //COMPLETE RequestSuppliesHelperFirst
                return srm;
            }
        }
    }
}