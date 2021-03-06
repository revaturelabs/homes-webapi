//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HousingAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tenant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tenant()
        {
            this.MaintenanceRequests = new HashSet<MaintenanceRequest>();
            this.SupplyRequests = new HashSet<SupplyRequest>();
            this.TenantCarRelationships = new HashSet<TenantCarRelationship>();
        }
    
        public int tenantId { get; set; }
        public Nullable<int> contactId { get; set; }
        public Nullable<int> batchId { get; set; }
        public Nullable<int> housingUnitId { get; set; }
        public Nullable<int> genderId { get; set; }
        public System.DateTime moveInDate { get; set; }
        public Nullable<bool> hasMoved { get; set; }
        public Nullable<bool> hasKey { get; set; }
    
        public virtual Batch Batch { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual HousingUnit HousingUnit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplyRequest> SupplyRequests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TenantCarRelationship> TenantCarRelationships { get; set; }
    }
}
