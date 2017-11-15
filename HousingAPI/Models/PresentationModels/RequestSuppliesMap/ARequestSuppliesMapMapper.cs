namespace HousingAPI.Models.HousingModels
{
    public abstract class ARequestSuppliesMapMapper
    {
        public int RequestSupplyMapId { get; set; }
        public int SuppliesRequestId { get; set; }
        public int SupplyId { get; set; }

        //public virtual SupplyRequest SupplyRequest { get; set; }
        //public virtual Supply Supply { get; set; }
    }
}