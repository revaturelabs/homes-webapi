using System;

namespace HousingAPI.Models.PresentationModels.Contact
{
    public class ContactMapper
    {
        public int ContactId { get; set; }
        public string ObjectId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}