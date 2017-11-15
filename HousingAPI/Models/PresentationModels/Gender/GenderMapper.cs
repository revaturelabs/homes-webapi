namespace HousingAPI.Models.HousingModels
{
    public abstract class GenderMapper
    {
        public int GenderId { get; set; }
        public string GenderOption { get; set; }

        //public IEnumerable<Tenant> Tenants { get; set; }
    }
}