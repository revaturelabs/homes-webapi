namespace HousingAPI.Models.HousingModels
{
    public abstract class HousingUnitMapper
    {
        public int HousingUnitId { get; set; }
        public int ProviderId { get; set; }
        public int AddressId { get; set; }
        public string HousingSignature { get; set; }
        public int Capacity { get; set; }

        //public Address Address { get; set; }
        //public Provider Provider { get; set; }
        //public ICollection<Tenant> Tenants { get; set; }
    }
}