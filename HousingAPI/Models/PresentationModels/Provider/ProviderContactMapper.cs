using HousingAPI.Models.PresentationModels.Contact;

namespace HousingAPI.Models.PresentationModels.Provider
{
    public class ProviderContactMapper : ProviderMapper
    {
        public ContactMapper Contact { get; set; }
    }
}