using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.HousingUnit;
using System.Collections.Generic;
using System.Linq;

namespace HousingAPI.Controllers.Helpers
{
    public class HousingUnitsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get all basic table
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
            var content = db.HousingUnits.Where(j => j.housingUnitId == housingUnitId).FirstOrDefault();

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

        // Get all with Address
        public List<HousingUnitAddressMapper> GetHousingUnitsWithAddress()
        {
            var content = db.HousingUnits.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<HousingUnitAddressMapper> housingUnits = new List<HousingUnitAddressMapper>();

                foreach (var item in content)
                {
                    AddressesHelper address = new AddressesHelper();
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

        // Get one with Address
        public HousingUnitAddressMapper GetHousingUnitWithAddress(int housingUnitId)
        {
            var content = db.HousingUnits.Where(j => j.housingUnitId == housingUnitId).FirstOrDefault();

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

                    Address = address.GetAddress(housingUnitId)
                };

                return housingUnit;
            }
            return null;
        }

        // Get all with Address, used in providers
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

                foreach (var item in content)
                {
                    AddressesHelper address = new AddressesHelper();
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

        // Get all with Provider
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

        // Get one with Provider
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

        // Get all with Provider
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

        // Get one with Provider
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


        /*
        // PUT: api/HousingUnits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHousingUnit(int id, HousingUnit housingUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != housingUnit.housingUnitId)
            {
                return BadRequest();
            }

            db.Entry(housingUnit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HousingUnitExists(id))
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

        // POST: api/HousingUnits
        [ResponseType(typeof(HousingUnit))]
        public IHttpActionResult PostHousingUnit(HousingUnit housingUnit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HousingUnits.Add(housingUnit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = housingUnit.housingUnitId }, housingUnit);
        }

        // DELETE: api/HousingUnits/5
        [ResponseType(typeof(HousingUnit))]
        public IHttpActionResult DeleteHousingUnit(int id)
        {
            HousingUnit housingUnit = db.HousingUnits.Find(id);
            if (housingUnit == null)
            {
                return NotFound();
            }

            db.HousingUnits.Remove(housingUnit);
            db.SaveChanges();

            return Ok(housingUnit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HousingUnitExists(int id)
        {
            return db.HousingUnits.Count(e => e.housingUnitId == id) > 0;
        }
        */
    }
}