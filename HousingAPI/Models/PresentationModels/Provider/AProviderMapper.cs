namespace HousingAPI.Models.PresentationModels.Provider
{
    public abstract class AProviderMapper
    {
        public int ProviderId { get; set; }
        public int ContactId { get; set; }
        public string CompanyName { get; set; }
    }
}