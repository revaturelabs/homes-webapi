using System.Collections.Generic;

namespace HousingAPI.Models.HousingModels
{
    public class ProviderMapper
    {


        public int providerId { get; set; }
        public int contactId { get; set; }
        public string companyName { get; set; }

        public virtual Contact Contact { get; set; }

        //public virtual IEnumerable<HousingUnit> HousingUnits { get; set; }
    }
}