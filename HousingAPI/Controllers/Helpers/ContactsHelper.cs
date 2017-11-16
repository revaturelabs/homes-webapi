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
            var toBeMapped = db.Contacts.ToList();
            if(toBeMapped.Count() == 0)
            {
                return null;
            }
            else
            {
                List<ContactMapper> cml = new List<ContactMapper>();

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
        }

        // Get single contact by id
        public ContactMapper GetContact(int )
        {
            var contact = db.Contacts.FirstOrDefault(i => i.contactId == id);
            if (contact == null)
            {
                return null;
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
 