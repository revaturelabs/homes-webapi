using System;

namespace HousingAPI.Models.HousingModels
{
    public class ContactMapper
    {
        public int BatchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
    }
}