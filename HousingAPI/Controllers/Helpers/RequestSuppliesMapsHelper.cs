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
using HousingAPI.Models.PresentationModels.RequestSuppliesMap;

namespace HousingAPI.Controllers.Helpers
{
    public class RequestSuppliesMapsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get all basic tables
        // DEFAULT CRUD
        public IEnumerable<RequestSuppliesMapMapper> GetRequestSuppliesMaps()
        {
            var content = db.RequestSuppliesMaps.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<RequestSuppliesMapMapper> maps = new List<RequestSuppliesMapMapper>();
                foreach (var item in content)
                {
                    RequestSuppliesMapMapper map = new RequestSuppliesMapMapper()
                    {
                        RequestSupplyMapId = item.requestSupplyMapId,
                        SuppliesRequestId = item.suppliesRequestId ?? default(int),
                        SupplyId = item.supplyId ?? default(int)
                    };
                    maps.Add(map);
                }
                return maps;
            }
        }

        // Get one basic table
        // DEFAULT CRUD
        public RequestSuppliesMapMapper GetRequestSuppliesMap(int requestSupplyMapId)
        {
            RequestSuppliesMap content = db.RequestSuppliesMaps.FirstOrDefault(j => j.requestSupplyMapId == requestSupplyMapId);
            if (content == null)
            {
                return null;
            }
            else
            {
                RequestSuppliesMapMapper map = new RequestSuppliesMapMapper()
                {
                    RequestSupplyMapId = content.requestSupplyMapId,
                    SuppliesRequestId = content.suppliesRequestId ?? default(int),
                    SupplyId = content.supplyId ?? default(int)
                };
                return map;
            }
        }

        // Get all mapping with supply by request - USED IN REQUEST
        // DEFAULT
        // RETURNS A SUPPLY REQUEST MAP BY SUPPLY REQUEST ID WITH: Supplies
        public IEnumerable<RequestSuppliesMapSupplyMapper> GetRequestSuppliesMapsWithSupplyByRequest(int suppliesRequestId)
        {
            var content = db.RequestSuppliesMaps.Where(j => j.suppliesRequestId == suppliesRequestId).ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<RequestSuppliesMapSupplyMapper> maps = new List<RequestSuppliesMapSupplyMapper>();
                SuppliesHelper supply = new SuppliesHelper();
                foreach (var item in content)
                {
                    RequestSuppliesMapSupplyMapper map = new RequestSuppliesMapSupplyMapper()
                    {
                        RequestSupplyMapId = item.requestSupplyMapId,
                        SuppliesRequestId = item.suppliesRequestId ?? default(int),
                        SupplyId = item.supplyId ?? default(int),

                        Supply = supply.GetSupply(item.supplyId ?? 0)
                    };
                    maps.Add(map);
                }
                return maps;
            }
        }

        /*
       // Get all mapping with supply
       public IEnumerable<RequestSuppliesMapSupplyMapper> GetRequestSuppliesMapsWithSupply()
       {
           var content = db.RequestSuppliesMaps.ToList();
           if (content.Count() == 0)
           {
               return null;
           }
           else
           {
               List<RequestSuppliesMapSupplyMapper> maps = new List<RequestSuppliesMapSupplyMapper>();
               SuppliesHelper supply = new SuppliesHelper();
               foreach (var item in content)
               {
                   RequestSuppliesMapSupplyMapper map = new RequestSuppliesMapSupplyMapper()
                   {
                       RequestSupplyMapId = item.requestSupplyMapId,
                       SuppliesRequestId = item.suppliesRequestId ?? default(int),
                       SupplyId = item.supplyId ?? default(int),

                       Supply = supply.GetSupply(item.supplyId ?? 0)
                   };
                   maps.Add(map);
               }
               return maps;
           }
       }
       */

        /*
        // Get one mapping with supply
        public RequestSuppliesMapSupplyMapper GetRequestSuppliesMapWithSupply(int requestSupplyMapId)
        {
            RequestSuppliesMap content = db.RequestSuppliesMaps.FirstOrDefault(j => j.requestSupplyMapId == requestSupplyMapId);
            if (content == null)
            {
                return null;
            }
            else
            {
                SuppliesHelper supply = new SuppliesHelper();
                RequestSuppliesMapSupplyMapper map = new RequestSuppliesMapSupplyMapper()
                {
                    RequestSupplyMapId = content.requestSupplyMapId,
                    SuppliesRequestId = content.suppliesRequestId ?? default(int),
                    SupplyId = content.supplyId ?? default(int),

                    Supply = supply.GetSupply(content.supplyId ?? 0)
                };
                return map;
            }
        }
        */
    }
}