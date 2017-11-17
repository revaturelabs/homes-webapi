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

        //Get all basic tables
        public IEnumerable<SupplyRequestMapper> GetSupplyRequests()
        {
            var content = db.SupplyRequests.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<SupplyRequestMapper> requests = new List<SupplyRequestMapper>();

                foreach (var item in content)
                {
                    SupplyRequestMapper request = new SupplyRequestMapper
                    {
                        SupplyRequestId = item.supplyRequestId,
                        TenantId = item.tenantId ?? default(int),
                        Active = item.active ?? default(bool)
                    };
                    requests.Add(request);
                }
                return requests;
            }
        }

        //Get one basic table
        public SupplyRequestMapper GetSupplyRequest(int supplyRequestId)
        {
            SupplyRequest content = db.SupplyRequests.FirstOrDefault(i => i.supplyRequestId == supplyRequestId);
            if (content == null)
            {
                return null;
            }
            else
            {
                SupplyRequestMapper request = new SupplyRequestMapper
                {
                    SupplyRequestId = content.supplyRequestId,
                    TenantId = content.tenantId ?? default(int),
                    Active = content.active ?? default(bool)
                };
                return request;
            }
        }

        //Get all requests with supplies
        public IEnumerable<SupplyRequestSupplyMapper> GetSupplyRequestsWithSupplies()
        {
            var content = db.SupplyRequests.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<SupplyRequestSupplyMapper> requests = new List<SupplyRequestSupplyMapper>();
                RequestSuppliesMapsHelper map = new RequestSuppliesMapsHelper();
                foreach (var item in content)
                {
                    SupplyRequestSupplyMapper request = new SupplyRequestSupplyMapper
                    {
                        SupplyRequestId = item.supplyRequestId,
                        TenantId = item.tenantId ?? default(int),
                        Active = item.active ?? default(bool),

                        RequestSuppliesMaps = map.GetRequestSuppliesWithSupplyMapsByRequest(item.supplyRequestId)
                    };
                    requests.Add(request);
                }
                return requests;
            }
        }

        //Get one request with supplies
        public SupplyRequestSupplyMapper GetSupplyRequestWithSupplies(int supplyRequestId)
        {
            SupplyRequest content = db.SupplyRequests.FirstOrDefault(i => i.supplyRequestId == supplyRequestId);
            if (content == null)
            {
                return null;
            }
            else
            {
                RequestSuppliesMapsHelper map = new RequestSuppliesMapsHelper();
                SupplyRequestSupplyMapper request = new SupplyRequestSupplyMapper
                {
                    SupplyRequestId = content.supplyRequestId,
                    TenantId = content.tenantId ?? default(int),
                    Active = content.active ?? default(bool),

                    RequestSuppliesMaps = map.GetRequestSuppliesWithSupplyMapsByRequest(content.supplyRequestId)
                };
                return request;
            }
        }
    }
}
