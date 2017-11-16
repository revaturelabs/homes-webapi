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
            List<AProviderMapper> providers = new List<AProviderMapper>();
            foreach (var item in provMapper)
            {
                AProviderMapper provider = new AProviderMapper
                {
                    ProviderId = item.providerId,
                    ContactId = item.contactId ?? 0,
                    CompanyName = item.companyName
                };
            }
            return providers;
        }

        // GET: api/Providers/5
        public AProviderMapper GetProvider(int id)
        {
            var provider = db.Providers.FirstOrDefault(p => p.providerId == id);
            if (provider == null)
            {
                AProviderMapper provMapper = new AProviderMapper();
                return provMapper;
            }
            else
            {
                AProviderMapper apm = new AProviderMapper
                {
                    ProviderId  = provider.providerId,
                    ContactId   = provider.contactId ?? 0,
                    CompanyName = provider.companyName
                };
                return apm;
            }
        }


        // Not complete
        public ProviderContactMapper GetProviderWithContact(int id)
        {
            var provider = db.Providers.FirstOrDefault(p => p.providerId == id);
            if (provider == null)
            {
                ProviderContactMapper provMapper = new ProviderContactMapper();
                return provMapper;
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


    }

}