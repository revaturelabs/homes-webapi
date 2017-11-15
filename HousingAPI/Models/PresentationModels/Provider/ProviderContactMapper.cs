using HousingAPI.Models.PresentationModels.Contact;

namespace HousingAPI.Models.PresentationModels.Provider
{
    public class ProviderContactMapper : AProviderMapper
    {
        public ContactMapper Contact { get; set; }
    }
}