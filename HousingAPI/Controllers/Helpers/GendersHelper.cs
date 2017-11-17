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

        // Get all basic tables
        public IEnumerable<GenderMapper> GetGenders()
        {
            var content = db.Genders.ToList();
            if(content.Count() == 0)
            {
                return null;
            }
            else
            {
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
        }

        // Get one basic table
        public GenderMapper GetGender(int genderId)
        {
            var content = db.Genders.FirstOrDefault(j => j.genderId == genderId);
            if (content == null)
            {
                return null;
            }
            else
            {
                GenderMapper gender = new GenderMapper()
                {
                    GenderId = content.genderId,
                    GenderOption = content.genderOption
                };
                return gender;
            }
        }
    }
}