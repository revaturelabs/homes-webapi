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
using HousingAPI.Models.PresentationModels.Provider;

namespace HousingAPI.Controllers.Helpers
{
    public class ProvidersHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Providers
        public IEnumerable<AProviderMapper> GetProviders()
        {
            var provMapper = db.Providers.ToList();
            List <AProviderMapper> providers = new List<AProviderMapper>();
            foreach(var item in provMapper)
            {
                AProviderMapper provider = new AProviderMapper
                {
                    ProviderId  = item.providerId,
                    ContactId   = item.contactId ?? 0,
                    CompanyName = item.companyName
                };
            } 
            return providers;
        }

        // GET: api/Providers/5
        [ResponseType(typeof(Provider))]
        public IHttpActionResult GetProvider(int id)
        {
            ProvidersHelper provider = db.ProvidersHelper.Find(id);
            if (provider == null)
            {
                return NotFound();
            }

            return Ok(provider);
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