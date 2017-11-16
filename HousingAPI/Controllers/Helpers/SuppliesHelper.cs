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

        // GET: api/Supplies
        public IEnumerable<SupplyMapper> GetSupplies()
        {
            var supMap = db.Supplies.ToList();
            List<SupplyMapper> supplies = new List<SupplyMapper>();
            foreach (var item in supMap)
            {
                SupplyMapper supply = new SupplyMapper
                {
                    SupplyId    = item.supplyId,
                    SupplyName  = item.supplyName
                };
                supplies.Add(supply);
            }
            return supplies;
        }

        // GET: api/Supplies/5
        [ResponseType(typeof(Supply))]
        public SupplyMapper GetSupply(int id)
        {
            var supply = db.Supplies.FirstOrDefault(s => s.supplyId == id);
            if (supply == null)
            {
                SupplyMapper supMap = new SupplyMapper();
                return supMap;
            }
            else
            {
                SupplyMapper sm = new SupplyMapper();
                {
                    sm.SupplyId = supply.supplyId;
                    sm.SupplyName = supply.supplyName;
                };
                return sm;
            }
        }