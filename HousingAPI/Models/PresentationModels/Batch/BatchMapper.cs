using System;

namespace HousingAPI.Models.PresentationModels.Batch
{
    public class BatchMapper
    {
        public int BatchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
    }
}