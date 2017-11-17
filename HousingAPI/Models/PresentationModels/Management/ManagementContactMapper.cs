using HousingAPI.Models.PresentationModels.Contact;

namespace HousingAPI.Models.PresentationModels.Management
{
    public class ManagementContactMapper : ManagementMapper
    {
        public ContactMapper Contact { get; set; }
    }
}