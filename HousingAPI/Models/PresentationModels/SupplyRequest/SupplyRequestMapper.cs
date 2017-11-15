namespace HousingAPI.Models.HousingModels
{
    public abstract class SupplyRequestMapper
    {
        public int SupplyRequestId { get; set; }
        public int TenantId { get; set; }
        public bool Active { get; set; }

        //public virtual ICollection<RequestSuppliesMap> RequestSuppliesMaps { get; set; }
        //public virtual Tenant Tenant { get; set; }
    }
}