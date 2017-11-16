namespace HousingAPI.Models.PresentationModels.HousingUnit
{
    public class HousingUnitMapper
    {
        public int HousingUnitId { get; set; }
        public int ProviderId { get; set; }
        public int AddressId { get; set; }
        public string HousingSignature { get; set; }
        public int Capacity { get; set; }
    }
}