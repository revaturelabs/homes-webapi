﻿namespace HousingAPI.Models.HousingModels
{
    public abstract class ATenantCarRelationshipMapper
    {
        public int RelationshipId { get; set; }
        public int TenantId { get; set; }
        public bool ParkingPassStatus { get; set; }

        //public virtual Tenant Tenant { get; set; }
    }

}