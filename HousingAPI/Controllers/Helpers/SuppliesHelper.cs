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
using HousingAPI.Models.PresentationModels.Supply;

namespace HousingAPI.Controllers.Helpers
{
    public class SuppliesHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get All basic tables
        // DEFAULT CRUD
        public IEnumerable<SupplyMapper> GetSupplies()
        {
            var content = db.Supplies.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<SupplyMapper> supplies = new List<SupplyMapper>();
                foreach (var item in content)
                {
                    SupplyMapper supply = new SupplyMapper
                    {
                        SupplyId = item.supplyId,
                        SupplyName = item.supplyName
                    };
                    supplies.Add(supply);
                }
                return supplies;
            }
        }

        // Get One basic table
        // DEFAULT CRUD
        public SupplyMapper GetSupply(int supplyId)
        {
            var content = db.Supplies.FirstOrDefault(s => s.supplyId == supplyId);
            if (content == null)
            {
                return null;
            }
            else
            {
                SupplyMapper supply = new SupplyMapper
                {
                    SupplyId = content.supplyId,
                    SupplyName = content.supplyName
                };
                return supply;
            }
        }
    }
}