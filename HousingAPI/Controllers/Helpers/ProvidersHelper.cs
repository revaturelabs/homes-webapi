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

        // Get All basic tables
        public IEnumerable<ProviderMapper> GetProviders()
        {
            var content = db.Providers.ToList();
            if(content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<ProviderMapper> providers = new List<ProviderMapper>();
                foreach (var item in content)
                {
                    ProviderMapper provider = new ProviderMapper
                    {
                        ProviderId = item.providerId,
                        ContactId = item.contactId ?? 0,
                        CompanyName = item.companyName
                    };
                    providers.Add(provider);
                }
                return providers;
            }
        }

        // Get One basic table
        public ProviderMapper GetProvider(int providerId)
        {
            var content = db.Providers.FirstOrDefault(p => p.providerId == providerId);
            if (content == null)
            {
                return null;
            }
            else
            {
                ProviderMapper provider = new ProviderMapper
                {
                    ProviderId  = content.providerId,
                    ContactId   = content.contactId ?? 0,
                    CompanyName = content.companyName
                };
                return provider;
            }
        }

        // Get All providers with contact
        public List<ProviderContactMapper> GetProvidersWithContact()
        {
            var content = db.Providers.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<ProviderContactMapper> providers = new List<ProviderContactMapper>();
                ContactsHelper contact = new ContactsHelper();
                foreach (var item in content)
                {
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
        }

        // Get One provider with contact
        public ProviderContactMapper GetProviderWithContact(int providerId)
        {
            var content = db.Providers.FirstOrDefault(p => p.providerId == providerId);
            if (content == null)
            {
                return null;
            }
            else
            {
                ContactsHelper contact = new ContactsHelper();
                ProviderContactMapper provider = new ProviderContactMapper
                {
                    ProviderId = content.providerId,
                    ContactId = content.contactId ?? 0,
                    CompanyName = content.companyName,

                    Contact = contact.GetContact(content.contactId ?? 0)
                };
                return provider;
            }
        }

        // Get All providers with units
        public List<ProviderUnitsMapper> GetProvidersWithUnits()
        {
            var content = db.Providers.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<ProviderUnitsMapper> providers = new List<ProviderUnitsMapper>();
                HousingUnitsHelper housing = new HousingUnitsHelper();
                foreach (var item in content)
                {
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
        }

        // Get One provider with units
        public ProviderUnitsMapper GetProviderWithUnits(int providerId)
        {
            var content = db.Providers.FirstOrDefault(p => p.providerId == providerId);
            if (content == null)
            {
                return null;
            }
            else
            {
                HousingUnitsHelper housing = new HousingUnitsHelper();
                ProviderUnitsMapper provider = new ProviderUnitsMapper
                {
                    ProviderId = content.providerId,
                    ContactId = content.contactId ?? 0,
                    CompanyName = content.companyName,

                    HousingUnits = housing.GetHousingUnitsWithAddressbyProvider(content.providerId)
                };
                return provider;
            }
        }
    }
}