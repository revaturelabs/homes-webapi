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

namespace HousingAPI.Controllers.APIControllers
{
    public class ProvidersController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Providers
        public IHttpActionResult GetProviders()
        {
            var helper = new ProvidersHelper();
            var result = helper.GetProviders();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/Providers/5
        [ResponseType(typeof(Provider))]
        public IHttpActionResult GetProvider(int id)
        {
            var helper = new ProvidersHelper();
            var result = helper.GetProvider(id);
            //Provider provider = db.Providers.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/Providers/WithContact
        [Route("api/Providers/WithContact")]
        public IHttpActionResult GetProvidersWithContact()
        {
            var helper = new ProvidersHelper();
            var result = helper.GetProvidersWithContact();
            if (result != null)
                return Ok(result);

            return NotFound();
        }
        
        // GET api/Providers/WithContact
        [Route("api/Providers/WithContact/{id}")]
        public IHttpActionResult GetProviderWithContact(int id)
        {
            var helper = new ProvidersHelper();
            var result = helper.GetProviderWithContact(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }
        
        // GET: api/Providers/WithUnits
        [Route("api/Providers/WithUnits")]
        public IHttpActionResult GetProvidersWithUnits()
        {
            var helper = new ProvidersHelper();
            var result = helper.GetProvidersWithUnits();
            if (result != null)
                return Ok(result);

            return NotFound();
        }
        
        // GET api/Providers/WithUnits
        [Route("api/Providers/WithUnits/{id}")]
        public IHttpActionResult GetProviderWithUnits(int id)
        {
            var helper = new ProvidersHelper();
            var result = helper.GetProviderWithUnits(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }
        
        // GET api/Providers/WithMaintenanceRequest
        [Route("api/Providers/WithMaintenanceRequest/{id}")]
        public IHttpActionResult GetProviderWithMaintenanceRequest(int id)
        {
            var helper = new ProvidersHelper();
            var result = helper.GetProviderWithMaintenanceRequest(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // PUT: api/Providers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProvider(int id, Provider provider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != provider.providerId)
            {
                return BadRequest();
            }

            db.Entry(provider).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderExists(id))
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

        // POST: api/Providers
        [ResponseType(typeof(Provider))]
        public IHttpActionResult PostProvider(Provider provider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Providers.Add(provider);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = provider.providerId }, provider);
        }

        // DELETE: api/Providers/5
        [ResponseType(typeof(Provider))]
        public IHttpActionResult DeleteProvider(int id)
        {
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return NotFound();
            }

            db.Providers.Remove(provider);
            db.SaveChanges();

            return Ok(provider);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProviderExists(int id)
        {
            return db.Providers.Count(e => e.providerId == id) > 0;
        }
    }
}