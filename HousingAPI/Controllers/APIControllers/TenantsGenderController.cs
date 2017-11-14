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
    public class TenantsGenderController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        [ResponseType(typeof(TenantsGenderController))]
        public TenantsGenderViewModel GetTenantsGender(int genderId)
        {
            Gender g = db.Genders.Find(genderId);
            List<Tenant> tenants_ = db.Tenants.Where(r => r.genderId == genderId).ToList();
            TenantsGenderViewModel tGenders = new TenantsGenderViewModel
            {
                gender = g,
                tenants = tenants_
            };
            return tGenders;
        }
    }
}