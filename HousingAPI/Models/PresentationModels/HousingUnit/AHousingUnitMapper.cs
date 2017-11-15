namespace HousingAPI.Models.HousingModels
{
    public abstract class AHousingUnitMapper
    {
        public int HousingUnitId { get; set; }
        public int ProviderId { get; set; }
        public int AddressId { get; set; }
        public string HousingSignature { get; set; }
        public int Capacity { get; set; }
    }
}