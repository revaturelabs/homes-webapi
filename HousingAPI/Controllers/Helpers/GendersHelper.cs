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
using HousingAPI.Models.PresentationModels.Gender;

namespace HousingAPI.Controllers.Helpers
{
    public class GendersHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Genders
        public IEnumerable<GenderMapper> GetGenders()
        {
            var content = db.Genders.ToList();
            List<GenderMapper> genders = new List<GenderMapper>();
            foreach (var item in content)
            {
                GenderMapper gender = new GenderMapper()
                {
                    GenderId = item.genderId,
                    GenderOption = item.genderOption
                };
                genders.Add(gender);
            }
            return genders;
        }

        public GenderMapper GetGender(int id)
        {
            var content = db.Genders.Where(j => j.genderId == id).FirstOrDefault();
            if (content != null)
            {
                GenderMapper gender = new GenderMapper()
                {
                    GenderId = content.genderId,
                    GenderOption = content.genderOption


                };
                return gender;
            }

            return new GenderMapper();
        }


    }
}