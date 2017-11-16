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
using HousingAPI.Models.PresentationModels.Gender;

namespace HousingAPI.Controllers.Helpers
{
    public class GendersHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Genders
        public IEnumerable<GenderMapper> GetGenders()
        {
            var content = db.Genders.ToList();
            if(content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<GenderMapper> genders = new List<GenderMapper>();
                foreach (var item in content)
                {
                    GenderMapper gender = new GenderMapper()
                    {
                        GenderId = item.genderId,
                        GenderOption = item.genderOption
                    };
                    genders.Add(gender);
                }
                return genders;
            }
        }

        public GenderMapper GetGender(int genderId)
        {
            var content = db.Genders.Where(j => j.genderId == genderId).FirstOrDefault();
            if (content == null)
            {
                return null;
            }
            else
            {
                GenderMapper gender = new GenderMapper()
                {
                    GenderId = content.genderId,
                    GenderOption = content.genderOption
                };
                return gender;
            }
        }


        /*
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
        */
    }
}