using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.HousingUnit;
using System.Collections.Generic;
using System.Linq;

namespace HousingAPI.Controllers.Helpers
{
    public class HousingUnitsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // 
        public IEnumerable<AHousingUnitMapper> GetHousingUnits()
        {
            var content = db.HousingUnits.ToList();
            List<AHousingUnitMapper> housingUnits = new List<AHousingUnitMapper>();
            foreach (var item in content)
            {
                AHousingUnitMapper housingUnit = new AHousingUnitMapper()
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

        // 
        public AHousingUnitMapper GetHousingUnit(int id)
        {
            var content = db.HousingUnits.Where(j => j.housingUnitId == id).FirstOrDefault();

            if (content != null)
            {
                AHousingUnitMapper housingUnit = new AHousingUnitMapper()
                {
                    HousingUnitId = content.housingUnitId,
                    ProviderId = content.providerId ?? 0,
                    AddressId = content.addressId ?? 0,
                    HousingSignature = content.housingSignature,
                    Capacity = content.capacity
                };

                return housingUnit;
            }
            return new AHousingUnitMapper();
        }

        public HousingUnitAddressMapper GetHousingUnitWithAddress(int id)
        {
            var content = db.HousingUnits.Where(j => j.housingUnitId == id).FirstOrDefault();

            if (content != null)
            {
                AddressesHelper address = new AddressesHelper();
                HousingUnitAddressMapper housingUnit = new HousingUnitAddressMapper()
                {
                    HousingUnitId = content.housingUnitId,
                    ProviderId = content.providerId ?? 0,
                    AddressId = content.addressId ?? 0,
                    HousingSignature = content.housingSignature,
                    Capacity = content.capacity,

                    Address = address.GetAddress(id)
                };

                return housingUnit;
            }
            return new HousingUnitAddressMapper();
        }

        public HousingUnitProviderMapper GetHousingUnitWithProvider(int id)
        {
            var content = db.HousingUnits.Where(j => j.housingUnitId == id).FirstOrDefault();

            if (content != null)
            {
                AddressesHelper address = new AddressesHelper();
                ProviderHelper provider = new ProviderHelper();
                HousingUnitProviderMapper housingUnit = new HousingUnitProviderMapper()
                {
                    HousingUnitId = content.housingUnitId,
                    ProviderId = content.providerId ?? 0,
                    AddressId = content.addressId ?? 0,
                    HousingSignature = content.housingSignature,
                    Capacity = content.capacity,

                    Address = address.GetAddress(id),
                    Provider = provider.GetProvider(id)
                };

                return housingUnit;
            }
            return new HousingUnitProviderMapper();
        }

    }
}