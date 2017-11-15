namespace HousingAPI.Models.HousingModels
{
    public class RequestSuppliesMapMapper
    {
        public int RequestSupplyMapId { get; set; }
        public int SuppliesRequestId { get; set; }
        public int SupplyId { get; set; }

        public Supply Supply { get; set; }
    }
}