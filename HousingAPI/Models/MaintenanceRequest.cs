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
    
    public partial class MaintenanceRequest
    {
        public int maintenanceRequestId { get; set; }
        public Nullable<int> tenantId { get; set; }
        public Nullable<bool> active { get; set; }
        public string message { get; set; }
    
        public virtual Tenant Tenant { get; set; }
    }
}
