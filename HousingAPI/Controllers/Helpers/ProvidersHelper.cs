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
using HousingAPI.Models.PresentationModels.HousingUnit;

namespace HousingAPI.Controllers.Helpers
{
    public class ProvidersHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get all basic table
        public IEnumerable<ProviderMapper> GetProviders()
        {
            var content = db.Providers.ToList();
            List<ProviderMapper> providers = new List<ProviderMapper>();
            foreach (var item in content)
            {
                ProviderMapper provider = new ProviderMapper
                {
                    ProviderId = item.providerId,
                    ContactId = item.contactId ?? 0,
                    CompanyName = item.companyName
                };
            }
            return providers;
        }

        // Get one basic table
        public ProviderMapper GetProvider(int id)
        {
            var provider = db.Providers.FirstOrDefault(p => p.providerId == id);
            if (provider == null)
            {
                return null;
            }
            else
            {
                ProviderMapper apm = new ProviderMapper
                {
                    ProviderId  = provider.providerId,
                    ContactId   = provider.contactId ?? 0,
                    CompanyName = provider.companyName
                };
                return apm;
            }
        }

        // Get all with contact
        public List<ProviderContactMapper> GetProvidersWithContact()
        {
            var content = db.Providers.ToList();
            List<ProviderContactMapper> providers = new List<ProviderContactMapper>();
            foreach(var item in content)
            {
                ContactsHelper contact = new ContactsHelper();
                ProviderContactMapper provider = new ProviderContactMapper
                {
                    ProviderId = item.providerId,
                    ContactId = item.contactId ?? 0,
                    CompanyName = item.companyName,

                    Contact = contact.GetContact(item.contactId ?? 0)
                };
                providers.Add(provider);
            }
            return providers;
        }

        // Get one with contact
        public ProviderContactMapper GetProviderWithContact(int id)
        {
            var provider = db.Providers.FirstOrDefault(p => p.providerId == id);
            if (provider == null)
            {
                return null;
            }
            else
            {
                ContactsHelper ch = new ContactsHelper();
                ProviderContactMapper apm = new ProviderContactMapper
                {
                    ProviderId = provider.providerId,
                    ContactId = provider.contactId ?? 0,
                    CompanyName = provider.companyName,

                    Contact = ch.GetContact(provider.contactId ?? 0)
                };
                return apm;
            }
        }

        // Get all with contact
        public List<ProviderUnitsMapper> GetProvidersWithUnit()
        {
            var content = db.Providers.ToList();
            List<ProviderUnitsMapper> providers = new List<ProviderUnitsMapper>();
            foreach (var item in content)
            {
                HousingUnitsHelper housing = new HousingUnitsHelper();
                
                ProviderUnitsMapper provider = new ProviderUnitsMapper
                {
                    ProviderId = item.providerId,
                    ContactId = item.contactId ?? 0,
                    CompanyName = item.companyName,

                    HousingUnits = housing.GetHousingUnitsWithAddressbyProvider(item.providerId)
                };
                providers.Add(provider);
            }
            return providers;
        }

        // Get one with contact
        public ProviderUnitsMapper GetProviderWithUnit(int id)
        {
            var provider = db.Providers.FirstOrDefault(p => p.providerId == id);
            if (provider == null)
            {
                return null;
            }
            else
            {
                HousingUnitsHelper housing = new HousingUnitsHelper();

                ProviderUnitsMapper apm = new ProviderUnitsMapper
                {
                    ProviderId = provider.providerId,
                    ContactId = provider.contactId ?? 0,
                    CompanyName = provider.companyName,

                    HousingUnits = housing.GetHousingUnitsWithAddressbyProvider(provider.providerId)
                };
                return apm;
            }
        }

        /*
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
        */
    }

}