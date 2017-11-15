namespace HousingAPI.Models.HousingModels
{
    public abstract class AProviderMapper
    {
        public int ProviderId { get; set; }
        public int ContactId { get; set; }
        public string CompanyName { get; set; }

        public virtual Contact Contact { get; set; }

        //public virtual IEnumerable<HousingUnit> HousingUnits { get; set; }
    }
}