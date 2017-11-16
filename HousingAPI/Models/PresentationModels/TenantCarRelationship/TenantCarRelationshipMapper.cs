using HousingAPI.Models.PresentationModels.Tenant;

namespace HousingAPI.Models.PresentationModels.TenantCarRelationship
{
    public class TenantCarRelationshipMapper
    {
        public int RelationshipId { get; set; }
        public int TenantId { get; set; }
        public bool ParkingPassStatus { get; set; }
    }
}