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
        public IEnumerable<HousingUnitMapper> GetHousingUnits()
        {
            var content = db.HousingUnits.ToList();
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

        // 
        public HousingUnitMapper GetHousingUnit(int id)
        {
            var content = db.HousingUnits.Where(j => j.housingUnitId == id).FirstOrDefault();

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
            return null;
        }

        public HousingUnitProviderMapper GetHousingUnitWithProvider(int id)
        {
            var content = db.HousingUnits.Where(j => j.housingUnitId == id).FirstOrDefault();

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

                    Address = address.GetAddress(id),
                    Provider = provider.GetProviderWithContact(id)
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