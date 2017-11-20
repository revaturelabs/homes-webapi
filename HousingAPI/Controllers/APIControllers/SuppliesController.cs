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
using HousingAPI.Controllers.Helpers;
using HousingAPI.Models.PresentationModels.Supply;

namespace HousingAPI.Controllers.APIControllers
{
    public class SuppliesController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Supplies
        [ResponseType(typeof(IEnumerable<SupplyMapper>))]
        public IHttpActionResult GetSupplies()
        {
            var helper = new SuppliesHelper();
            var result = helper.GetSupplies();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/Supplies/5
        [ResponseType(typeof(SupplyMapper))]
        public IHttpActionResult GetSupply(int id)
        {

            var helper = new SuppliesHelper();
            var result = helper.GetSupply(id);
            //Supply supply = db.Supplies.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
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