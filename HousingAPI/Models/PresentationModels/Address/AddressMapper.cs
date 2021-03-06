﻿namespace HousingAPI.Models.PresentationModels.Address
{
    public class AddressMapper
    {
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string BuildingNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}