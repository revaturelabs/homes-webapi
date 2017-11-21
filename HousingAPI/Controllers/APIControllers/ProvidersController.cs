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
using HousingAPI.Models.PresentationModels.Provider;

namespace HousingAPI.Controllers.APIControllers
{
    public class ProvidersController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Providers
        [ResponseType(typeof(IEnumerable<ProviderMapper>))]
        public IHttpActionResult GetProviders()
        {
            var helper = new ProvidersHelper();
            var result = helper.GetProviders();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/Providers/5
        [ResponseType(typeof(ProviderMapper))]
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
        [ResponseType(typeof(IEnumerable<ProviderContactMapper>))]
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
        [ResponseType(typeof(ProviderContactMapper))]
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
        [ResponseType(typeof(IEnumerable<ProviderUnitsMapper>))]
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
        [ResponseType(typeof(ProviderUnitsMapper))]
        public IHttpActionResult GetProviderWithUnits(int id)
        {
            var helper = new ProvidersHelper();
            var result = helper.GetProviderWithUnits(id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // PUT: api/Providers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProvider(int id, [FromBody]Provider provider)
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
        public IHttpActionResult PostProvider([FromBody]Provider provider)
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