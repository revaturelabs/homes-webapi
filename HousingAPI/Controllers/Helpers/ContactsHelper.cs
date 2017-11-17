using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HousingAPI.Models;
using HousingAPI.Models.PresentationModels.Contact;

namespace HousingAPI.Controllers.Helpers
{
    public class ContactsHelper
    {
        private HousingDBEntities db = new HousingDBEntities();

        // Get All basic tables
        public IEnumerable<ContactMapper> GetContacts()
        {
            var content = db.Contacts.ToList();
            if(content.Count() == 0)
            {
                return null;
            }
            else
            {
                List<ContactMapper> contacts = new List<ContactMapper>();

                foreach (var item in content)
                {
                    ContactMapper contact = new ContactMapper
                    {
                        ContactId = item.contactId,
                        Email = item.email,
                        FirstName = item.firstName,
                        LastName = item.lastName,
                        ObjectId = item.objectId,
                        PhoneNumber = item.phoneNumber
                    };
                    contacts.Add(contact);
                }
                return contacts;
            }
        }

        // Get Single basic table
        public ContactMapper GetContact(int contactId)
        {
            var content = db.Contacts.FirstOrDefault(i => i.contactId == contactId);
            if (content == null)
            {
                return null;
            }
            else
            {
                ContactMapper contact = new ContactMapper
                {
                    ContactId = content.contactId,
                    Email = content.email,
                    FirstName = content.firstName,
                    LastName = content.lastName,
                    ObjectId = content.objectId,
                    PhoneNumber = content.phoneNumber
                };
                return contact;
            }
        }
    }
}
 