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
using HousingAPI.Controllers.Helpers;
using HousingAPI.Models.PresentationModels.Contact;

namespace HousingAPI.Controllers.APIControllers
{
    public class ContactsController : ApiController
    {
        private HousingDBEntities db = new HousingDBEntities();

        // GET: api/Contacts
        [ResponseType(typeof(IEnumerable<ContactMapper>))]
        public IHttpActionResult GetContacts()
        {
            var helper = new ContactsHelper();
            var result = helper.GetContacts();
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // GET: api/Contacts/5
        [ResponseType(typeof(ContactMapper))]
        public IHttpActionResult GetContact(int id)
        {
            var helper = new ContactsHelper();
            var result = helper.GetContact(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/Contacts/5
        [Route("api/Contacts/GetContactByObjectId/{id}")]
        [ResponseType(typeof(int))]
        public IHttpActionResult GetContact(string id)
        {
            var helper = new ContactsHelper();
            var result = helper.GetContactIdByObjectId(id);
            if (result == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, [FromBody]Contact contact)
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
        public IHttpActionResult PostContact([FromBody]Contact contact)
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
    }
}