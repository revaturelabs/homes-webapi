namespace HousingAPI.Models.HousingModels
{
    public abstract class RequestSuppliesMapMapper
    {
        public int requestSupplyMapId { get; set; }
        public int suppliesRequestId { get; set; }
        public int supplyId { get; set; }

        //public virtual SupplyRequest SupplyRequest { get; set; }
        //public virtual Supply Supply { get; set; }
    }
}