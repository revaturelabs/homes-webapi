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
using System.Web.Http.Cors;
using System.Security.Claims;

namespace HousingAPI.Controllers.APIControllers
{
    //[Authorize]
    //[EnableCors("*", "*", "*")]
    public class GendersController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Genders
        public IHttpActionResult GetGenders()
        {
            var helper = new GendersHelper();
            var result = helper.GetGenders();

            if (result != null)
                return Ok(result);

            return NotFound();
            //return db.Genders;
        }
        // GET: api/Genders/5
        [ResponseType(typeof(Gender))]
        public IHttpActionResult GetGender(int id)
        {
            var helper = new GendersHelper();
            var result = helper.GetGender(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/Genders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGender(int id, Gender gender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gender.genderId)
            {
                return BadRequest();
            }

            db.Entry(gender).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenderExists(id))
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

        // POST: api/Genders
        [ResponseType(typeof(Gender))]
        public IHttpActionResult PostGender(Gender gender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Genders.Add(gender);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gender.genderId }, gender);
        }

        // DELETE: api/Genders/5
        [ResponseType(typeof(Gender))]
        public IHttpActionResult DeleteGender(int id)
        {
            Gender gender = db.Genders.Find(id);
            if (gender == null)
            {
                return NotFound();
            }

            db.Genders.Remove(gender);
            db.SaveChanges();

            return Ok(gender);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GenderExists(int id)
        {
            return db.Genders.Count(e => e.genderId == id) > 0;
        }
    }
}