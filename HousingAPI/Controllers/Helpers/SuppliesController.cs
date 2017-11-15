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

namespace HousingAPI.Controllers.Helpers
{
    public class SuppliesController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Supplies
        public IQueryable<Supply> GetSupplies()
        {
            return db.Supplies;
        }

        // GET: api/Supplies/5
        [ResponseType(typeof(Supply))]
        public IHttpActionResult GetSupply(int id)
        {
            Supply supply = db.Supplies.Find(id);
            if (supply == null)
            {
                return NotFound();
            }

            return Ok(supply);
        }

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
    }
}