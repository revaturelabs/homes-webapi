using HousingAPI.Models.PresentationModels.Batch;
using HousingAPI.Models.PresentationModels.Contact;
using HousingAPI.Models.PresentationModels.Gender;
using HousingAPI.Models.PresentationModels.TenantCarRelationship;

namespace HousingAPI.Models.PresentationModels.Tenant
{
    public class TenantInfoMapper : ATenantMapper
    {
        public ABatchMapper Batch { get; set; }
        public ContactMapper Contact { get; set; }
        public GenderMapper Gender { get; set; }
        public TenantCarRelationshipMapper TenantCarRelationships { get; set; }
    }
}