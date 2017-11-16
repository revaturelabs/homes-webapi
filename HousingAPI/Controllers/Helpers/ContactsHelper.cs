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

        //Get all contacts
        public IEnumerable<ContactMapper> GetContacts()
        {
            List<ContactMapper> cml = new List<ContactMapper>();
            var toBeMapped = db.Contacts.ToList();
            foreach (var contact in toBeMapped)
            {
                ContactMapper cm = new ContactMapper();

                cm.ContactId = contact.contactId;
                cm.Email = contact.email;
                cm.FirstName = contact.firstName;
                cm.LastName = contact.lastName;
                cm.ObjectId = contact.objectId;
                cm.PhoneNumber = contact.phoneNumber;

                cml.Add(cm);
            }

            return cml;
        }

        //Get single contact by id
        public ContactMapper GetContact(int id)
        {
            var contact = db.Contacts.FirstOrDefault(i => i.contactId == id);
            if (contact == null)
            {
                ContactMapper cm = new ContactMapper();
                return cm;
            }
            else
            {
                ContactMapper cm = new ContactMapper();
                cm.ContactId = contact.contactId;
                cm.Email = contact.email;
                cm.FirstName = contact.firstName;
                cm.LastName = contact.lastName;
                cm.ObjectId = contact.objectId;
                cm.PhoneNumber = contact.phoneNumber;
                return cm;
            }
        }

    }
}