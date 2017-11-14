using HousingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace HousingAPI.Controllers.APIControllers
{
    public class HousingOccupantsController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        [ResponseType(typeof(HousingUnit))]
        public TenantsHousingUnitViewModel GetHousingOccupants(int id)
        {
            HousingUnit housingU = db.HousingUnits.Find(id);
            List<Tenant> tenants_ = db.Tenants.Where(r => r.housingUnitId == housingU.housingUnitId).ToList();
            TenantsHousingUnitViewModel occupants = new TenantsHousingUnitViewModel {
                housingUnit = housingU,
                tenants = tenants_  
            };
            return occupants;
        }
    }
}
