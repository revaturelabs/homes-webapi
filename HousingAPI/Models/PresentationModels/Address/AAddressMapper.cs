namespace HousingAPI.Models.HousingModels
{
    public abstract class AAddressMapper
    {
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string BuildingNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        //public IList<HousingUnitMapper> HousingUnits { get; set; }
    }
}