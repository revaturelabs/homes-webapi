using HousingAPI.Models.PresentationModels.Tenant;

namespace HousingAPI.Models.HousingModels
{
    public class TenantCarRelationshipMapper
    {
        public int RelationshipId { get; set; }
        public int TenantId { get; set; }
        public bool ParkingPassStatus { get; set; }

        public TenantAddressMapper Tenant { get; set; }
    }
}