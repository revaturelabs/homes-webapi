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
                    SupplyId = item.supplyId,
                    SupplyName = item.supplyName
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
                return null;
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


        /*
        // PUT: api/Supplies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSupply(int id, Supply supply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supply.supplyId)
            {
                return BadRequest();
            }

            db.Entry(supply).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplyExists(id))
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

        // POST: api/Supplies
        [ResponseType(typeof(Supply))]
        public IHttpActionResult PostSupply(Supply supply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Supplies.Add(supply);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = supply.supplyId }, supply);
        }

        // DELETE: api/Supplies/5
        [ResponseType(typeof(Supply))]
        public IHttpActionResult DeleteSupply(int id)
        {
            Supply supply = db.Supplies.Find(id);
            if (supply == null)
            {
                return NotFound();
            }

            db.Supplies.Remove(supply);
            db.SaveChanges();

            return Ok(supply);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SupplyExists(int id)
        {
            return db.Supplies.Count(e => e.supplyId == id) > 0;
        }
        */
    }
}