using HousingAPI.Models.PresentationModels.Supply;

namespace HousingAPI.Models.PresentationModels.RequestSuppliesMap
{
    public class RequestSuppliesMapMapper
    {
        public int RequestSupplyMapId { get; set; }
        public int SuppliesRequestId { get; set; }
        public int SupplyId { get; set; }

        public SupplyMapper Supply { get; set; }
    }
}