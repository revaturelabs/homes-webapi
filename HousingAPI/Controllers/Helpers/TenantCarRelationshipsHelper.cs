﻿using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.TenantCarRelationship;
using System.Collections.Generic;
using System.Linq;

namespace HousingAPI.Controllers.Helpers
{
    public class TenantCarRelationshipsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get all basic tables
        // DEFAULT CRUD
        public IEnumerable<TenantCarRelationshipMapper> GetTenantCarRelationships()
        {
            var content = db.TenantCarRelationships.ToList();
            if (content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<TenantCarRelationshipMapper> tenantCarRelationships = new List<TenantCarRelationshipMapper>();
                foreach (var item in content)
                {
                    TenantCarRelationshipMapper tenantCarRelationship = new TenantCarRelationshipMapper()
                    {
                        RelationshipId = item.relationshipId,
                        TenantId = item.tenantId ?? default(int),
                        ParkingPassStatus = item.parkingPassStatus ?? default(bool),
                    };
                    tenantCarRelationships.Add(tenantCarRelationship);
                }
                return tenantCarRelationships;
            }
        }

        // Get all basic tables
        // DEFAULT CRUD
        public TenantCarRelationshipMapper GetTenantCarRelationships(int relationshipId)
        {
            var content = db.TenantCarRelationships.FirstOrDefault(j => j.relationshipId == relationshipId);
            if (content == null)
            {
                return null;
            }
            else
            {
                TenantCarRelationshipMapper tenantCarRelationship = new TenantCarRelationshipMapper()
                {
                    RelationshipId = content.relationshipId,
                    TenantId = content.tenantId ?? default(int),
                    ParkingPassStatus = content.parkingPassStatus ?? default(bool),
                };
                return tenantCarRelationship;
            }
        }

        // Get one basic table
        // INSIDE HELPER: USED IN TENANT
        // RETURNS A TENANT CAR RELATIONSHIP FOR A TENANT
        public TenantCarRelationshipMapper GetTenantCarRelationship(int tenantId)
        {
            var content = db.TenantCarRelationships.FirstOrDefault(j => j.tenantId == tenantId);
            if (content == null)
            {
                return null;
            }
            else
            {
                TenantCarRelationshipMapper tenantCarRelationship = new TenantCarRelationshipMapper()
                {
                    RelationshipId = content.relationshipId,
                    TenantId = content.tenantId ?? default(int),
                    ParkingPassStatus = content.parkingPassStatus ?? default(bool),
                };
                return tenantCarRelationship;
            }
        }
    }
}