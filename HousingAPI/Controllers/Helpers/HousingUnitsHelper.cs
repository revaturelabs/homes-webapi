using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.HousingUnit;
using System.Collections.Generic;
using System.Linq;

namespace HousingAPI.Controllers.Helpers
{
    public class HousingUnitsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get All basic tables
        // DEFAULT CRUD
        public IEnumerable<HousingUnitMapper> GetHousingUnits()
        {
            var content = db.HousingUnits.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<HousingUnitMapper> housingUnits = new List<HousingUnitMapper>();
                foreach (var item in content)
                {
                    HousingUnitMapper housingUnit = new HousingUnitMapper()
                    {
                        HousingUnitId = item.housingUnitId,
                        ProviderId = item.providerId ?? 0,
                        AddressId = item.addressId ?? 0,
                        HousingSignature = item.housingSignature,
                        Capacity = item.capacity
                    };
                    housingUnits.Add(housingUnit);
                }
                return housingUnits;
            }
        }

        // Get One basic table
        // DEFAULT CRUD
        public HousingUnitMapper GetHousingUnit(int housingUnitId)
        {
            var content = db.HousingUnits.FirstOrDefault(j => j.housingUnitId == housingUnitId);

            if (content == null)
            {
                return null;
            }
            else
            {
                HousingUnitMapper housingUnit = new HousingUnitMapper()
                {
                    HousingUnitId = content.housingUnitId,
                    ProviderId = content.providerId ?? 0,
                    AddressId = content.addressId ?? 0,
                    HousingSignature = content.housingSignature,
                    Capacity = content.capacity
                };

                return housingUnit;
            }
        }

        // Get All with Address
        // DEFAULT
        // RETURNS ALL THE HOUSING UNITS WITH: Address
        public IEnumerable<HousingUnitAddressMapper> GetHousingUnitsWithAddress()
        {
            var content = db.HousingUnits.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<HousingUnitAddressMapper> housingUnits = new List<HousingUnitAddressMapper>();
                AddressesHelper address = new AddressesHelper();
                foreach (var item in content)
                {
                    HousingUnitAddressMapper housingUnit = new HousingUnitAddressMapper()
                    {
                        HousingUnitId = item.housingUnitId,
                        ProviderId = item.providerId ?? 0,
                        AddressId = item.addressId ?? 0,
                        HousingSignature = item.housingSignature,
                        Capacity = item.capacity,

                        Address = address.GetAddress(item.addressId ?? 0)
                    };
                    housingUnits.Add(housingUnit);
                }
                return housingUnits;
            }
        }

        // Get One with Address
        // DEAFULT
        // RETURNS ALL THE HOUSING UNITS BY ID WITH: Address
        public HousingUnitAddressMapper GetHousingUnitWithAddress(int housingUnitId)
        {
            var content = db.HousingUnits.FirstOrDefault(j => j.housingUnitId == housingUnitId);
            if (content == null)
            {
                return null;
            }
            else
            {
                AddressesHelper address = new AddressesHelper();
                HousingUnitAddressMapper housingUnit = new HousingUnitAddressMapper()
                {
                    HousingUnitId = content.housingUnitId,
                    ProviderId = content.providerId ?? 0,
                    AddressId = content.addressId ?? 0,
                    HousingSignature = content.housingSignature,
                    Capacity = content.capacity,

                    Address = address.GetAddress(content.addressId ?? 0)
                };

                return housingUnit;
            }
        }
        
        // Get All housing units with Provider
        // DEFAULT
        // RETURNS ALL THE HOUSING UNITS WITH: Address, and  Provider with Contact
        public IEnumerable<HousingUnitProviderMapper> GetHousingUnitsWithProvider()
        {
            var content = db.HousingUnits.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<HousingUnitProviderMapper> housingUnits = new List<HousingUnitProviderMapper>();
                AddressesHelper address = new AddressesHelper();
                ProvidersHelper provider = new ProvidersHelper();
                foreach (var item in content)
                {
                    HousingUnitProviderMapper housingUnit = new HousingUnitProviderMapper()
                    {
                        HousingUnitId = item.housingUnitId,
                        ProviderId = item.providerId ?? 0,
                        AddressId = item.addressId ?? 0,
                        HousingSignature = item.housingSignature,
                        Capacity = item.capacity,

                        Address = address.GetAddress(item.addressId ?? 0),
                        Provider = provider.GetProviderWithContact(item.providerId ?? 0)
                    };
                    housingUnits.Add(housingUnit);
                }
                return housingUnits;
            }
        }

        // Get One housing unit with Provider
        // DEFAULT
        // RETURNS ONE HOUSING UNIT BY ID WITH: Address, and Provider with Contact
        public HousingUnitProviderMapper GetHousingUnitWithProvider(int housingUnitId)
        {
            var content = db.HousingUnits.Where(j => j.housingUnitId == housingUnitId).FirstOrDefault();
            if (content == null)
            {
                return null;
            }
            else
            {
                AddressesHelper address = new AddressesHelper();
                ProvidersHelper provider = new ProvidersHelper();
                HousingUnitProviderMapper housingUnit = new HousingUnitProviderMapper()
                {
                    HousingUnitId = content.housingUnitId,
                    ProviderId = content.providerId ?? 0,
                    AddressId = content.addressId ?? 0,
                    HousingSignature = content.housingSignature,
                    Capacity = content.capacity,

                    Address = address.GetAddress(housingUnitId),
                    Provider = provider.GetProviderWithContact(housingUnitId)
                };
                return housingUnit;
            }
        }

        // Get All housing units with Tenants
        // DEFAULT
        // RETURNS ALL THE HOUSING UNITS WITH: Tenants with Batch, Contact, Gender, and Car Relationship
        public IEnumerable<HousingUnitTenantInfoMapper> GetHousingUnitsWithTenants()
        {
            var content = db.HousingUnits.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<HousingUnitTenantInfoMapper> housingUnits = new List<HousingUnitTenantInfoMapper>();
                AddressesHelper address = new AddressesHelper();
                TenantsHelper tenants = new TenantsHelper();
                foreach (var item in content)
                {
                    HousingUnitTenantInfoMapper housingUnit = new HousingUnitTenantInfoMapper()
                    {
                        HousingUnitId = item.housingUnitId,
                        ProviderId = item.providerId ?? 0,
                        AddressId = item.addressId ?? 0,
                        HousingSignature = item.housingSignature,
                        Capacity = item.capacity,

                        Address = address.GetAddress(item.addressId ?? 0),
                        Tenants = tenants.GetTenantsWithInfoByHousing(item.housingUnitId)
                    };
                    housingUnits.Add(housingUnit);
                }
                return housingUnits;
            }
        }

        // Get One housing unit with Tenants
        // DEFAULT
        // RETURNS ONE HOUSING UNIT WITH: Tenants with Batch, Contact, Gender, and Car Relationship
        public HousingUnitTenantInfoMapper GetHousingUnitWithTenants(int housingUnitId)
        {
            var content = db.HousingUnits.Where(j => j.housingUnitId == housingUnitId).FirstOrDefault();

            if (content == null)
            {
                return null;
            }
            else
            {
                AddressesHelper address = new AddressesHelper();
                TenantsHelper tenants = new TenantsHelper();
                HousingUnitTenantInfoMapper housingUnit = new HousingUnitTenantInfoMapper()
                {
                    HousingUnitId = content.housingUnitId,
                    ProviderId = content.providerId ?? 0,
                    AddressId = content.addressId ?? 0,
                    HousingSignature = content.housingSignature,
                    Capacity = content.capacity,

                    Address = address.GetAddress(housingUnitId),
                    Tenants = tenants.GetTenantsWithInfoByHousing(content.housingUnitId)
                };
                return housingUnit;
            }
        }

        // Get All housing units of a provider
        // INSIDE HELPER: USED IN PROVIDERS
        // RETURNS ALL THE HOUSING BY PROVIDER UNITS WITH: Address
        public IEnumerable<HousingUnitAddressMapper> GetHousingUnitsWithAddressbyProvider(int contactID)
        {
            var content = db.HousingUnits.Where(j => j.Provider.contactId == contactID).ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<HousingUnitAddressMapper> housingUnits = new List<HousingUnitAddressMapper>();
                AddressesHelper address = new AddressesHelper();
                foreach (var item in content)
                {
                    HousingUnitAddressMapper housingUnit = new HousingUnitAddressMapper()
                    {
                        HousingUnitId = item.housingUnitId,
                        ProviderId = item.providerId ?? 0,
                        AddressId = item.addressId ?? 0,
                        HousingSignature = item.housingSignature,
                        Capacity = item.capacity,

                        Address = address.GetAddress(item.addressId ?? 0)
                    };
                    housingUnits.Add(housingUnit);
                }
                return housingUnits;
            }
        }

        /*
         * Maintenance and Supply Requests
         * Called in other controllers
         */

        /*
        // Get All maintenance request
        // DEFAULT
        // RETURNS ALL THE HOUSING UNITS: Address, and Tenants with Maintenance Requests
        public IEnumerable<HousingUnitProviderTenantMaintenanceMapper> GetHousingUnitsMaintenanceRequest()
        {
            var content = db.HousingUnits.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<HousingUnitProviderTenantMaintenanceMapper> housingUnits = new List<HousingUnitProviderTenantMaintenanceMapper>();
                AddressesHelper address = new AddressesHelper();
                TenantsHelper tenants = new TenantsHelper();
                foreach (var item in content)
                {
                    HousingUnitProviderTenantMaintenanceMapper housingUnit = new HousingUnitProviderTenantMaintenanceMapper()
                    {
                        HousingUnitId = item.housingUnitId,
                        ProviderId = item.providerId ?? 0,
                        AddressId = item.addressId ?? 0,
                        HousingSignature = item.housingSignature,
                        Capacity = item.capacity,

                        Address = address.GetAddress(item.addressId ?? 0),
                        Tenants = tenants.GetTenantsWithMaintenance(item.housingUnitId)
                    };
                    housingUnits.Add(housingUnit);
                }
                return housingUnits;
            }
        }
        */

        /*
        // Get All maintenance request by Provider
        // DEFAULT
        // RETURNS ALL THE HOUSING UNITS BY PROVIDER WITH: Address, and Tenants with Maintenance Requests
        public IEnumerable<HousingUnitProviderTenantMaintenanceMapper> GetHousingUnitsMaintenanceRequestByProvider(int contactID)
        {
            var content = db.HousingUnits.Where(j => j.Provider.contactId == contactID).ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<HousingUnitProviderTenantMaintenanceMapper> housingUnits = new List<HousingUnitProviderTenantMaintenanceMapper>();
                AddressesHelper address = new AddressesHelper();
                TenantsHelper tenants = new TenantsHelper();
                foreach (var item in content)
                {
                    HousingUnitProviderTenantMaintenanceMapper housingUnit = new HousingUnitProviderTenantMaintenanceMapper()
                    {
                        HousingUnitId = item.housingUnitId,
                        ProviderId = item.providerId ?? 0,
                        AddressId = item.addressId ?? 0,
                        HousingSignature = item.housingSignature,
                        Capacity = item.capacity,

                        Address = address.GetAddress(item.addressId ?? 0),
                        Tenants = tenants.GetTenantsWithMaintenance(item.housingUnitId)
                    };
                    housingUnits.Add(housingUnit);
                }
                return housingUnits;
            }
        }
        */

        // Get All supply request 
        // DEFAULT
        // RETURNS ALL THE HOUSING UNITS WITH: Address, and Tenants with Supply Requests
        public IEnumerable<HousingUnitProviderTenantSupplyMapper> GetHousingUnitsSupplyRequest()
        {
            var content = db.HousingUnits.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<HousingUnitProviderTenantSupplyMapper> housingUnits = new List<HousingUnitProviderTenantSupplyMapper>();
                AddressesHelper address = new AddressesHelper();
                TenantsHelper tenants = new TenantsHelper();
                foreach (var item in content)
                {
                    HousingUnitProviderTenantSupplyMapper housingUnit = new HousingUnitProviderTenantSupplyMapper
                    {
                        HousingUnitId = item.housingUnitId,
                        ProviderId = item.providerId ?? 0,
                        AddressId = item.addressId ?? 0,
                        HousingSignature = item.housingSignature,
                        Capacity = item.capacity,

                        Address = address.GetAddress(item.addressId ?? 0),
                        Tenants = tenants.GetTenantsWithSupplies(item.housingUnitId)
                    };
                    housingUnits.Add(housingUnit);
                }
                return housingUnits;
            }
        }

        // Get All supply request by House Unit/tenat
        // DEFAULT
        // RETURNS ALL THE HOUSING UNITS WITH: Address, and Tenants with Supply Requests
        public IEnumerable<HousingUnitProviderTenantSupplyMapper> GetHousingUnitsSupplyRequest(int housingUnitId)
        {
            var content = db.HousingUnits.Where(j => j.housingUnitId == housingUnitId).ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<HousingUnitProviderTenantSupplyMapper> housingUnits = new List<HousingUnitProviderTenantSupplyMapper>();
                AddressesHelper address = new AddressesHelper();
                TenantsHelper tenants = new TenantsHelper();
                foreach (var item in content)
                {
                    HousingUnitProviderTenantSupplyMapper housingUnit = new HousingUnitProviderTenantSupplyMapper
                    {
                        HousingUnitId = item.housingUnitId,
                        ProviderId = item.providerId ?? 0,
                        AddressId = item.addressId ?? 0,
                        HousingSignature = item.housingSignature,
                        Capacity = item.capacity,

                        Address = address.GetAddress(item.addressId ?? 0),
                        Tenants = tenants.GetTenantsWithSupplies(item.housingUnitId)
                    };
                    housingUnits.Add(housingUnit);
                }
                return housingUnits;
            }
        }
    }
}