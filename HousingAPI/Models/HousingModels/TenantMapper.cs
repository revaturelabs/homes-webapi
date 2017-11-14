using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousingAPI.Models.HousingModels
{
    public class TenantMapper
    {
        public int TenantId { get; set; }
        public int ContactId { get; set; }
        public int BatchId { get; set; }
        public int HousingUnitId { get; set; }
        public int GenderId { get; set; }
        public DateTime MoveInDate { get; set; }
        public bool HasMoved { get; set; }
        public bool HasKey { get; set; }

        //public virtual Batch Batch { get; set; }
        //public virtual Contact Contact { get; set; }
        //public virtual Gender Gender { get; set; }
        //public virtual HousingUnit HousingUnit { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SupplyRequest> SupplyRequests { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<TenantCarRelationship> TenantCarRelationships { get; set; }

    }
}