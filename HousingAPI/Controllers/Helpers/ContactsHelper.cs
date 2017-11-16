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

        // Get all contacts
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

        // Get single contact by id
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

        /*
         // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.contactId)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contacts
        [ResponseType(typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contacts.Add(contact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contact.contactId }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.Contacts.Remove(contact);
            db.SaveChanges();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.contactId == id) > 0;
        }
        */

    }
}
 