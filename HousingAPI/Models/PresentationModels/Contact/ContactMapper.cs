using System;

namespace HousingAPI.Models.PresentationModels.Contact
{
    public class ContactMapper
    {
        public int BatchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
    }
}