namespace HousingAPI.Models.HousingModels
{
    public abstract class AGenderMapper
    {
        public int GenderId { get; set; }
        public string GenderOption { get; set; }

        //public IEnumerable<Tenant> Tenants { get; set; }
    }
}