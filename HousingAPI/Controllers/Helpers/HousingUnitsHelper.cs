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
        public HousingUnitMapper GetHousingUnit(int housingUnitId)
        {
            var content = db.HousingUnits.FirstOrDefault(j => j.housingUnitId == housingUnitId);

            if (content != null)
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
            return null;
        }

        // Get All with Address
        public List<HousingUnitAddressMapper> GetHousingUnitWithAddress()
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

                    Address = address.GetAddress(housingUnitId)
                };

                return housingUnit;
            }
        }

        // Get All housing units of a provider
        public List<HousingUnitAddressMapper> GetHousingUnitsWithAddressbyProvider(int providerId)
        {
            var content = db.HousingUnits.Where(j => j.providerId == providerId).ToList();
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

        // Get All maintenance request by provider
        public List<HousingUnitProviderTenantMaintenanceMapper> GetHousingUnitsMaintenanceRequest(int providerId)
        {
            var content = db.HousingUnits.Where(j => j.providerId == providerId).ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<HousingUnitProviderTenantMaintenanceMapper> housingUnits = new List<HousingUnitProviderTenantMaintenanceMapper>();

                foreach (var item in content)
                {
                    AddressesHelper address = new AddressesHelper();
                    TenantsHelper tenants = new TenantsHelper();
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

        // Get All supply request by provider
        public List<HousingUnitProviderTenantSupplyMapper> GetHousingUnitsSupplyRequest(int providerId)
        {
            var content = db.HousingUnits.Where(j => j.providerId == providerId).ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<HousingUnitProviderTenantSupplyMapper> housingUnits = new List<HousingUnitProviderTenantSupplyMapper>();

                foreach (var item in content)
                {
                    AddressesHelper address = new AddressesHelper();
                    TenantsHelper tenants = new TenantsHelper();
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

        // Get All housing units with Provider
        public List<HousingUnitProviderMapper> GetHousingUnitsWithProvider()
        {
            var content = db.HousingUnits.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<HousingUnitProviderMapper> housingUnits = new List<HousingUnitProviderMapper>();

                foreach (var item in content)
                {
                    AddressesHelper address = new AddressesHelper();
                    ProvidersHelper provider = new ProvidersHelper();
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
        public HousingUnitProviderMapper GetHousingUnitWithProvider(int housingUnitId)
        {
            var content = db.HousingUnits.Where(j => j.housingUnitId == housingUnitId).FirstOrDefault();

            if (content != null)
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
            return null;
        }

        // Get All housing units with Tenants
        public List<HousingUnitTenantInfoMapper> GetHousingUnitsWithTenants()
        {
            var content = db.HousingUnits.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<HousingUnitTenantInfoMapper> housingUnits = new List<HousingUnitTenantInfoMapper>();

                foreach (var item in content)
                {
                    AddressesHelper address = new AddressesHelper();
                    TenantsHelper tenants = new TenantsHelper();
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
        public HousingUnitTenantInfoMapper GetHousingUnitWithTenats(int housingUnitId)
        {
            var content = db.HousingUnits.Where(j => j.housingUnitId == housingUnitId).FirstOrDefault();

            if (content != null)
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
            return null;
        }
    }
}